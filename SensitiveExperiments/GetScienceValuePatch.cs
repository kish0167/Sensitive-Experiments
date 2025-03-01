using HarmonyLib;
using UnityEngine;

namespace SensitiveExperiments
{
	[HarmonyPatch(typeof(ResearchAndDevelopment))]
	[HarmonyPatch(nameof(ResearchAndDevelopment.GetScienceValue), typeof(float),
		typeof(float), typeof(ScienceSubject), typeof(float))]
	public class GetScienceValuePatch
	{
		private static void Prefix(float dataAmount,
			float scienceValueRatio,
			ScienceSubject subject,
			float xmitScalar = 1f)
		{
			double referenceDataValue = (double)ResearchAndDevelopment.GetReferenceDataValue(dataAmount, subject);
			float num = Mathf.Min((float)referenceDataValue * subject.scientificValue * xmitScalar,
				subject.scienceCap * scienceValueRatio);
			float b = Mathf.Lerp((float)referenceDataValue, subject.scienceCap * scienceValueRatio, xmitScalar) *
			          xmitScalar;
			float result = Mathf.Max(Mathf.Min(subject.science + num, b) - subject.science, 0.0f);
			Debug.LogError($"{nameof(subject.science)}: {subject.science}\n" +
			               $"{nameof(subject.scientificValue)}: {subject.scientificValue}\n" +
			               $"{nameof(num)}: {num}\n" +
			               $"{nameof(b)}: {b}\n\n");
		}
	}
}
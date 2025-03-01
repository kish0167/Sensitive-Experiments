using HarmonyLib;
using UnityEngine;

namespace SensitiveExperiments
{
	[HarmonyPatch(typeof(ResearchAndDevelopment))]
	[HarmonyPatch(nameof(ResearchAndDevelopment.GetSubjectValue), typeof(float), typeof(ScienceSubject))]
	public class GetSubjectValuePatch
	{
		private static void Postfix(float subjectScience, ScienceSubject subject, ref float __result)
		{
			Debug.LogError("XXX-XXX");
			__result = 0.2f;
		}
	}
}
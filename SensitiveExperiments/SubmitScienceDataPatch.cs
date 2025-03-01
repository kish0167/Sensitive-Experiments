using HarmonyLib;
using UnityEngine;

namespace SensitiveExperiments
{
	public class SubmitScienceDataPatch
	{
		#region Public Nested Types

		[HarmonyPatch(typeof(ResearchAndDevelopment))]
		[HarmonyPatch(nameof(ResearchAndDevelopment.SubmitScienceData), typeof(float),
			typeof(float), typeof(ScienceSubject), typeof(float), typeof(ProtoVessel), typeof(bool))]
		public class GetExperimentSubjectPatch
		{
			#region Private methods

			private static void Prefix(float dataAmount,
				float scienceValueRatio,
				ScienceSubject subject,
				float xmitScalar,
				ProtoVessel source,
				bool reverseEngineered)
			{
				//Debug.LogError($"{nameof(ResearchAndDevelopment.SubmitScienceData)}:\n");
				//LocalUtils.Print(subject);
			}

			#endregion
		}

		#endregion
	}
}
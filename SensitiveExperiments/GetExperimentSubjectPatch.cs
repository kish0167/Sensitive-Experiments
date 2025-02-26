using HarmonyLib;
using UnityEngine;

namespace SensitiveExperiments
{
	[HarmonyPatch(typeof(ResearchAndDevelopment))]
	[HarmonyPatch(nameof(ResearchAndDevelopment.GetExperimentSubject), typeof(ScienceExperiment),
		typeof(ExperimentSituations), typeof(CelestialBody), typeof(string), typeof(string))]
	public class GetExperimentSubjectPatch
	{
		#region Private methods

		private static void Postfix(ref ScienceSubject __result)
		{
			__result.scientificValue = 0.5f;
			LocalUtils.Print(__result);
		}
		
		#endregion
	}
}
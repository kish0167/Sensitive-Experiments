using HarmonyLib;

namespace SensitiveExperiments
{
	[HarmonyPatch(typeof(ResearchAndDevelopment))]
	[HarmonyPatch(nameof(ResearchAndDevelopment.GetExperimentSubject), typeof(ScienceExperiment),
		typeof(ExperimentSituations), typeof(CelestialBody), typeof(string), typeof(string))]
	public class GetExperimentSubjectPatch
	{
		#region Private methods

		// affects only first time experiment submitted
		private static void Postfix(ref ScienceSubject __result)
		{
			__result.scientificValue = ScienceRescalingLogic.CalculateNewScienceValue(__result);
			// LocalUtils.Print(__result);
		}
		
		
		#endregion
	}
}
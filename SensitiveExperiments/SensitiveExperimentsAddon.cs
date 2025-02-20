using HarmonyLib;
using UnityEngine;

namespace SensitiveExperiments
{
	[KSPAddon(KSPAddon.Startup.EveryScene, false)]
	public class SensitiveExperimentsAddon : MonoBehaviour
	{
		#region Variables

		private Harmony _harmony;

		#endregion

		#region Unity lifecycle

		private void Start()
		{
			_harmony = new Harmony("com.KSP.SensitiveExperiments");
			_harmony.PatchAll();
			GameEvents.OnExperimentDeployed.Add(ExperimentDeployedCallback);
		}

		private void OnDestroy()
		{
			_harmony.UnpatchAll();
		}

		#endregion

		#region Private methods

		private void ExperimentDeployedCallback(ScienceData data)
		{
			Debug.LogError("science done!");
		}

		#endregion

		#region Local data

		[HarmonyPatch(typeof(ResearchAndDevelopment), nameof(ResearchAndDevelopment.GetReferenceDataValue))]
		private static class GetReferenceDataValuePatch
		{
			#region Private methods

			private static void Postfix(ref float __result)
			{
				Debug.LogError($"{nameof(ResearchAndDevelopment.GetReferenceDataValue)} returned {__result}");
			}

			#endregion
		}

		[HarmonyPatch(typeof(ResearchAndDevelopment), nameof(ResearchAndDevelopment.GetSubjectValue))]
		private static class GetSubjectValuePatch
		{
			#region Private methods

			private static void Postfix(ref float __result)
			{
				Debug.LogError($"{nameof(ResearchAndDevelopment.GetSubjectValue)} returned {__result}");
			}

			#endregion
		}
		
		[HarmonyPatch(typeof(ResearchAndDevelopment), nameof(ResearchAndDevelopment.GetNextScienceValue))]
		private static class GetNextScienceValuePatch
		{
			#region Private methods

			private static void Postfix(ref float __result)
			{
				Debug.LogError($"{nameof(ResearchAndDevelopment.GetNextScienceValue)} returned {__result}");
			}

			#endregion
		}
		
		[HarmonyPatch(typeof(ResearchAndDevelopment), nameof(ResearchAndDevelopment.GetExperimentSubject))]
		private static class GetExperimentSubjectPatch
		{
			#region Private methods

			private static void Postfix(ScienceSubject __result)
			{
				/*Debug.LogError($"{nameof(ResearchAndDevelopment.GetExperimentSubject)} returned ScienceSubject\n" +
				               $"subjectValue: {__result.subjectValue}\n" +
				               $"scientificValue: {__result.scientificValue}\n" +
				               $"applyScienceScale: {__result.applyScienceScale}\n" +
				               $"dataScale: {__result.dataScale}\n" +
				               $"scienceCap: {__result.scienceCap}\n" +
				               $"title: {__result.title}\n" +
				               $"science: {__result.science}\n");*/
				
			}

			#endregion
		}
		

		#endregion
	}
}
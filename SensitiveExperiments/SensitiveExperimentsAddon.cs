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
			//Debug.LogError("science done!");
		}

		#endregion
	}
}
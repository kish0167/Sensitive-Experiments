using HarmonyLib;
using UnityEngine;

namespace SensitiveExperiments
{
	[KSPAddon(KSPAddon.Startup.Flight, false)]
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
			data.scienceValueRatio += 400;
			data.labValue += 500;
			data.baseTransmitValue += 600;
			data.transmitBonus += 700;
			data.dataAmount += 300;
			data.scienceValueRatio = 1;
			Debug.LogError("science done!");
		}

		#endregion

		#region Local data

		[HarmonyPatch(typeof(ModuleScienceExperiment))]
		private class Patch { }

		#endregion
	}
}
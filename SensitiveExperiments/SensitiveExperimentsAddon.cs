using System;
using HarmonyLib;
using UnityEngine;
using Unity;

namespace SensitiveExperiments
{
	[KSPAddon(KSPAddon.Startup.Flight, false)]
	public class SensitiveExperimentsAddon : MonoBehaviour
	{
		#region Variables

		private Harmony _harmony;

		#endregion

		private void Start()
		{
			_harmony = new Harmony("com.KSP.SensitiveExperiments");
			_harmony.PatchAll();
		}

		private void Update()
		{
			
		}

		private void OnDestroy()
		{
			_harmony.UnpatchAll();
		}
	}
}
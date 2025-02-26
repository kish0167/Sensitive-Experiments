using HarmonyLib;
using UnityEngine;

namespace SensitiveExperiments
{
	[HarmonyPatch(typeof(ResearchAndDevelopment), nameof(ResearchAndDevelopment.GetReferenceDataValue))]
	public static class GetReferenceDataValuePatch
	{
		#region Private methods

		private static void Postfix(ref float __result)
		{
			//__result *= 0.1f;
			//Debug.LogError($"{nameof(ResearchAndDevelopment.GetReferenceDataValue)} returned {__result}");
		}

		#endregion
	}
}
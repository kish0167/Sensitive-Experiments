using HarmonyLib;
using UnityEngine;

namespace SensitiveExperiments
{
	[HarmonyPatch(typeof(ResearchAndDevelopment))]
	[HarmonyPatch(nameof(ResearchAndDevelopment.GetSubjectValue), typeof(float), typeof(ScienceSubject))]
	public static class GetSubjectValuePatch
	{
		private static float _baseValue = 1f;
		
		#region Private methods

		// affects only second and further times experiment submitted
		
		
		private static void Prefix(float subjectScience, ScienceSubject subject)
		{
			_baseValue = subject.scientificValue;
		}

		private static void Postfix(float subjectScience, ScienceSubject subject, ref float __result)
		{
			__result *= _baseValue;
		}
		
		#endregion
	}
}
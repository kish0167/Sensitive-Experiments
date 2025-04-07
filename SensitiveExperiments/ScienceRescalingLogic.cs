using UnityEngine;

namespace SensitiveExperiments
{
	public static class ScienceRescalingLogic
	{
		public static float CalculateNewScienceValue(ScienceSubject subject)
		{
			Part experimentModule = GetSubjectSource(subject);
			return 1f;
		}

		private static Part GetSubjectSource(ScienceSubject subject)
		{
			foreach (Part part in FlightGlobals.ActiveVessel.parts)
			{
				foreach (PartModule module in part.Modules)
				{
					if (!module.GetType().IsAssignableFrom(typeof(ModuleScienceExperiment)))
					{
						continue;
					}

					ModuleScienceExperiment moduleScienceExperiment = module as ModuleScienceExperiment;
					Debug.LogError(moduleScienceExperiment.experimentID + " - " + subject.id);
				}
			}
			
			return null;
		}
	}
}
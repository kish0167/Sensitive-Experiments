using UnityEngine;

namespace SensitiveExperiments
{
	public static class LocalUtils
	{
		public static void Print(ScienceSubject subject)
		{
			Debug.LogError("\n" +
			               $"ID: {subject.id}\n" +
			               $"Data Scale: {subject.dataScale}\n" +
			               $"Scientific Value: {subject.scientificValue}\n" +
			               $"Subject Value: {subject.subjectValue}\n" +
			               $"Science Cap: {subject.scienceCap}\n" +
			               $"Science: {subject.science}");
		}
	}
}
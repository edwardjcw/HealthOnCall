/*
	ScheduledTime.cs
		This class is in charge of keeping track of a range of days and times that a reminder
		is valid for. The class also provides a method bool IsMember(char, char) that checks
		a requested day and time against the array of valid days and times in the ScheduledTime.
*/

using System;

namespace HealthOnCall {
	public class ScheduledTime {
		char[] 	scheduledDays;
		char[] 	scheduledTimes;

		public ScheduledTime(char[] days, char[] times) {
			scheduledDays 	= days;
			scheduledTimes 	= times;
		}

		public char[] 	GetDayList() {
			return scheduledDays;
		}

		public char[]	GetTimeList() {
			return scheduledTimes;
		}

		public void 	SetDayList (char[] days) {
			scheduledDays = days;
		}

		public void 	SetTimeList (char[] times) {
			scheduledTimes = times;
		}

		public bool 	IsMember (char inputDay, char inputTime) {
			bool returnDay 	= false;
			bool returnTime = false;

			foreach (char day in scheduledDays) {
				if (day == inputDay) {
					returnDay = true;
				}
			}

			if (returnDay) {
				foreach (char time in scheduledTimes) {
					if (time == inputTime) {
						returnTime = true;
					}
				}
			}

			return returnTime && returnDay;
		}

	}
}
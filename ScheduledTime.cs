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
		int[] 	scheduleTimes;

		ScheduledTime(char[] days, int[] times) {
			scheduledDays 	= days;
			scheduleTimes 	= times;
		}

		char[] 	GetDayList() {
			return scheduledDays;
		}

		char[]	GetTimeList() {
			return scheduledTimes;
		}

		void 	SetDayList (char[] days) {
			scheduledDays = days;
		}

		void 	SetTimeList (char[] times) {
			scheduledTimes = times;
		}

		bool 	IsMember (char inputDay, char inputTime) {
			bool returnDay 	= false;
			bool returnTime = false;

			foreach (char day in scheduledDays) {
				if (day == inputDay) {
					returnDay = true;
				}
			}

			if (returnDay) {
				foreach (char time in scheduleTimes) {
					if (time == inputTime) {
						returnTime = true;
					}
				}
			}

			return returnTime && returnDay;
		}

	}
}
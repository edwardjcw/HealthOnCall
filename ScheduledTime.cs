using System;

namespace ScheduledTime {
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

		void 	SetDayList(char[] days) {
			scheduledDays = days;
		}

		void SetTimeList(char[] times) {
			scheduledTimes = times;
		}

	}
}
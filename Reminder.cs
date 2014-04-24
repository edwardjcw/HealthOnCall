using System;

namespace HealthOnCall {
	class Reminder {
		int 			id;
		string 			title;
		ScheduledTime	time;
		int 			pictureID;
		bool 			priority;

		Reminder(int inputID, string inputTitle, ScheduledTime inputTime, bool priority);

		void 			SetTitle (string inputTitle) {
			title = inputTitle;
		}

		string 			GetTitle () {
			return title;
		}

		int 			GetID() {
			return id;
		}

		bool 			GetPriority() {
			return priority;
		}

		void 			SetPriority(bool inputPriority) {
			priority = inputPriority;
		}

		bool 			ProbeTime (char inputDay, char inputTime) {
			return time.IsMember(day, time);
		}



	}
}
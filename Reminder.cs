/*
	Reminder.cs
		The Reminder object is in charge of keeping the data on a given reminder.
		The Scheduler will keep a collection of Reminder objects to probe with
		the Reminder.ProbeTime(char, char) method. 
*/

using System;

namespace HealthOnCall {
	class Reminder {
		int 			id;			// id will help the Scheduler in the deterministic ordering
									// of the given reminders
		string 			title;
		ScheduledTime	time;		// Keeps track of the range of valid days and times
		int 			pictureID;	// Just keep track of an image identifier and let the
									// controller handle the loading and displaying.
		bool 			priority;	// We define HIGH => medical; LOW => lifestyle

		Reminder(int inputID, string inputTitle, ScheduledTime inputTime, bool inputPriority) {
			id 			= inputID;
			title 		= inputTitle;
			time 		= inputTime;
			priority 	= inputPriority;
		}

		void 			SetTitle (string inputTitle) {
			title = inputTitle;
		}

		string 	GetTitle () {
			return title;
		}

		int GetID () {
			return id;
		}

		bool GetPriority () {
			return priority;
		}

		void SetPriority (bool inputPriority) {
			priority = inputPriority;
		}

		bool ProbeTime (char inputDay, char inputTime) {
			return time.IsMember(day, time);
		}



	}
}
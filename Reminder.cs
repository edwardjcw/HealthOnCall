/*
	Reminder.cs
		The Reminder object is in charge of keeping the data on a given reminder.
		The Scheduler will keep a collection of Reminder objects to probe with
		the Reminder.ProbeTime(char, char) method. 
*/

using System;
using System.Collections.Generic;

namespace HealthOnCall {
	class Reminder : IComparable<Reminder> {
		private int 			id;			// id will help the Scheduler in the deterministic ordering
											// of the given reminders
		private string 			title;
		private ScheduledTime	time;		// Keeps track of the range of valid days and times
		private int 			pictureID;	// Just keep track of an image identifier and let the
											// controller handle the loading and displaying.
		private bool 			priority;	// We define HIGH => medical; LOW => lifestyle

		public Reminder(int inputID, string inputTitle, ScheduledTime inputTime, int pID, bool inputPriority) {
			id 			= inputID;
			title 		= inputTitle;
			time 		= inputTime;
			pictureID 	= pID;
			priority 	= inputPriority;
		}

		public void SetPictureID (int pID) {
			pictureID = pID;
		}

		public int GetPictureID () {
			return pictureID;
		}

		public void SetTitle (string inputTitle) {
			title = inputTitle;
		}

		public string 	GetTitle () {
			return title;
		}

		public int GetID () {
			return id;
		}

		public bool GetPriority () {
			return priority;
		}

		public void SetPriority (bool inputPriority) {
			priority = inputPriority;
		}

		public int CompareTo(Reminder other) {
			if (other == null) return 1;
			else return id.CompareTo(other.GetID());
 		}

		public bool ProbeTime (char inputDay, char inputTime) {
			return time.IsMember(inputDay, inputTime);
		}



	}
}
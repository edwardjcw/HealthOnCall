/*
	Scheduler.cs
		The Scheduler is in charge of the synchronization of the application. 
		It monitors the time and delegates asynchronous tasks to the rest of the
		application. Scheduler tracks the reminders and monitors which
		reminders fall into the current time frame. It then composes a Queue of these
		reminders and sends the Queue to a controller.
*/

using System;
using System.Collections;

namespace HealthOnCall {
	class Scheduler {
		List<Reminder> reminders;
		int wake 		= 0;
		int breakfast 	= 0;
		int lunch 		= 0;
		int dinner 		= 0;
		int sleep 		= 0;

		Scheduler(int wakeTime, int breakfastTime, int lunchTime, int dinnerTime, int sleepTime) {
			wake 		= wakeTime;
			breakfast 	= breakfastTime;
			lunch 		= lunchTime;
			dinner 		= dinnerTime;
			sleep 		= sleepTime;
		}
		//Queue
/*

	Methods to implement:
		AddReminder
		DeleteReminder
		ConvertTime
		ConvertDay
		CheckTime -- debug of new time
		Save -- bit format
		Load -- bit format
		SendQueue



		*/
	}
}
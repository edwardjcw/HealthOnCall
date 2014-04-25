/*
	Scheduler.cs
		The Scheduler is in charge of the synchronization of the application. 
		It monitors the time and delegates asynchronous tasks to the rest of the
		application. Scheduler tracks the reminders and monitors which
		reminders fall into the current time frame. It then composes a Queue of these
		reminders and sends the Queue to a controller.

	Methods to implement:
		CheckTime -- debug of new time
		Save -- bit format
		Load -- bit format
		SendQueue
		GetListOfReminders

*/

using System;
using System.Collections.Generic;
//using System.Timers;
//using System.Threading;
//using System.Windows.Threading;
using Windows.UI.Xaml;


namespace HealthOnCall {
	public class Scheduler {
		List<Reminder> reminders;
		DateTime wake;
		DateTime breakfast;
		DateTime lunch;
		DateTime dinner;
		DateTime sleep;
		//System.Threading.Timer t;

        DispatcherTimer t = new DispatcherTimer();

		public Scheduler(DateTime wakeTime, DateTime breakfastTime, DateTime lunchTime, DateTime dinnerTime, DateTime sleepTime) {
			reminders 	= new List<Reminder>();
			wake 		= wakeTime;
			breakfast 	= breakfastTime;
			lunch 		= lunchTime;
			dinner 		= dinnerTime;
			sleep 		= sleepTime;

            t.Tick += FormQueue;
            CheckTime();
		}


		//Queue
		public void AddReminder (Reminder inputReminder) {
			//Console.WriteLine("Successfully added: {0}", inputReminder.GetTitle());
			reminders.Add(inputReminder);
			reminders.Sort();

		}

		private void DeleteReminder (Reminder inputReminder) {
			foreach (Reminder x in reminders) {
				if (x.GetID() == inputReminder.GetID()) {
					reminders.Remove(x);
				}
			}
		}

		public char ConvertTime (DateTime inputTime) {

			if (inputTime > wake && inputTime < breakfast) {
				return 'w';
			} else if (inputTime > breakfast && inputTime <= lunch) {
				return 'b';
			} else if (inputTime > lunch && inputTime <= dinner) {
				return 'l';
			} else if (inputTime > dinner && inputTime <= sleep - new TimeSpan(0,30,0)) {
				return 'd';
			} else {
				return 's';
			}
		}

		public char ConvertDay (DateTime inputDay) {
			switch (inputDay.DayOfWeek) {
				case DayOfWeek.Sunday:
					return 'g';
				case DayOfWeek.Monday:
					return 'm';
				case DayOfWeek.Tuesday:
					return 't';
				case DayOfWeek.Wednesday:
					return 'w';
				case DayOfWeek.Thursday:
					return 'r';
				case DayOfWeek.Friday:
					return 'f';
				case DayOfWeek.Saturday:
					return 's';
				default:
					return 'n';
			}
		}

        private void FormQueue(object sender, object e)
        {
			try {
				Queue<Reminder> scheduledReminders = new Queue<Reminder>();
				//Console.WriteLine("Congrats. Your clock didn't fail. Mom might still love you one day.");
				foreach (Reminder x in reminders) {
					//Console.WriteLine("We just saw {0} in DAR()!", x.GetTitle());
					if (x.GetPriority()) {
						if (x.ProbeTime(ConvertDay(DateTime.Now), ConvertTime(DateTime.Now))) {
							//Console.WriteLine("{0} enqueuing!", x.GetTitle());
							scheduledReminders.Enqueue(x);
						}
					}
				}

				foreach (Reminder x in reminders) {
					if (!x.GetPriority()) {
						if (x.ProbeTime(ConvertDay(DateTime.Now), ConvertTime(DateTime.Now))) {
							scheduledReminders.Enqueue(x);
						}
					}
				}
			} catch (Exception ex) {
				//Console.WriteLine("EX: {0}", ex.Message);
			}
		}

		public void CheckTime () {
			DateTime now = DateTime.Now;
			TimeSpan timeDifference = new TimeSpan(0, 0, 0);
			switch (ConvertTime(now)) {
				case 'w':
					timeDifference = breakfast - now;
					break;
				case 'b':
					timeDifference = lunch - now;
					break;
				case 'l':
					timeDifference = dinner - now;
					break;
				case 'd':
					timeDifference = sleep - now;
					break;
				case 's':
					timeDifference = now - wake;
					break;

			}

			try {
                t.Interval = timeDifference;
				
				//Console.WriteLine("What the hell t?");
			} catch (Exception ex) {
				//Console.WriteLine("Exception: ", ex.Message);
			}
			//Console.WriteLine(timeDifference);
			//DeployAsyncRoutines();

		}
	}
}
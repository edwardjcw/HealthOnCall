using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HealthOnCall
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddReminder : Page
    {

        public bool fromCamera = false;
        
        public AddReminder()
        {
            this.InitializeComponent();
            ready();
        }

        public AddReminder(bool fromCamera)
        {
            this.InitializeComponent();
            if (fromCamera)
            {
                image.Source = ImageID.GetImage(ImageID.GetLastID());
            }
            ready();
        }

        int imageID = 1;
        
        List<char> segment = new List<char>();
        List<char> days = new List<char>();

        void ready()
        {
            
            bool segmentChecked = checkWakeUp.IsChecked == true ||
                checkBreakfast.IsChecked == true ||
                checkLunch.IsChecked == true ||
                checkDinner.IsChecked == true ||
                checkBedTime.IsChecked == true;
            bool daysChecked = checkSunday.IsChecked == true ||
                checkMonday.IsChecked == true ||
                checkTuesday.IsChecked == true ||
                checkWednesday.IsChecked == true ||
                checkThursday.IsChecked == true ||
                checkFriday.IsChecked == true ||
                checkSaturday.IsChecked == true;            
            //picture ready?
            if (imageID > 0 && segmentChecked && daysChecked)
            {

                saveReminderButton.Visibility = Windows.UI.Xaml.Visibility.Visible;

            }
            else
            {
                saveReminderButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private void checkWakeUp_Checked(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkBreakfast_Checked(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkLunch_Checked(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkDinner_Checked(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkBedTime_Checked(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkSunday_Checked(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkMonday_Checked(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkTuesday_Checked(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkWednesday_Checked(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkThursday_Checked(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkFriday_Checked(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkSaturday_Checked(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkWakeUp_Click(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkBreakfast_Click(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkLunch_Click(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkDinner_Click(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkBedTime_Click(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkSunday_Click(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkMonday_Click(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkTuesday_Click(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkWednesday_Click(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkThursday_Click(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkFriday_Click(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void checkSaturday_Click(object sender, RoutedEventArgs e)
        {
            ready();
        }

        private void saveReminderButton_Click(object sender, RoutedEventArgs e)
        {
            //add reminder -- segment
            if (checkWakeUp.IsChecked == true)
            {
                segment.Add('w');
            }
            if (checkBreakfast.IsChecked == true)
            {
                segment.Add('b');
            }
            if (checkLunch.IsChecked == true)
            {
                segment.Add('l');
            }
            if (checkDinner.IsChecked == true)
            {
                segment.Add('d');
            }
            if (checkBedTime.IsChecked == true)
            {
                segment.Add('s');
            }

            //add reminder -- days
            if (checkSunday.IsChecked == true)
            {
                days.Add('g');
            }
            if (checkMonday.IsChecked == true)
            {
                days.Add('m');
            }
            if (checkTuesday.IsChecked == true)
            {
                days.Add('t');
            }
            if (checkWednesday.IsChecked == true)
            {
                days.Add('w');
            }
            if (checkThursday.IsChecked == true)
            {
                days.Add('r');
            }
            if (checkFriday.IsChecked == true)
            {
                days.Add('f');
            }
            if (checkSaturday.IsChecked == true)
            {
                days.Add('s');
            }

            //ADD THE REMINDER
            ScheduledTime st = new ScheduledTime(days.ToArray(), segment.ToArray());
            bool priority = checkPriority.IsChecked == true;
            Reminder reminder = new Reminder(textReminder.Text, st, ImageID.GetLastID(), priority);
            QuestionsPage.scheduler.AddReminder(reminder);
            this.Content = new ReminderPage(reminder);
        }

        private void takePictureButton_Click(object sender, RoutedEventArgs e)
        {
            BlankPage1 bp = new BlankPage1();
            this.Content = bp;


        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

    }
}

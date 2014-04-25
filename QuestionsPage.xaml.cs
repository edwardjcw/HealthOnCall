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
    public sealed partial class QuestionsPage : Page
    {

        List<string> questions = new List<string>()
        {
            "What time do you wake up?",
            "What time do you eat breakfast?",
            "What time do you eat lunch?",
            "What time do you eat dinner?",
            "What time do you go to bed?"
        };

        List<DateTime> times = new List<DateTime>() {DateTime.Today,DateTime.Today,DateTime.Today,DateTime.Today,DateTime.Today};

        int questionIndex = 0;
        
        public QuestionsPage()
        {
            this.InitializeComponent();
            textQuestion.Text = questions[questionIndex];
            UpdateButtons();
            
        }

        private void UpdateButtons()
        {
            timePicker.Time = times[questionIndex].TimeOfDay;
            if (questionIndex == 0)
            {
                goBackButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                okButton.Visibility = Windows.UI.Xaml.Visibility.Visible;

            }
            else if (questionIndex >= 4)
            {
                goBackButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                goBackButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                okButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            times[questionIndex] = DateTime.Today.Add(timePicker.Time);
            if (questionIndex >= 4)
            {
                ProceedMain();
            }
            else
            {
                textQuestion.Text = questions[++questionIndex];
                //save time
                UpdateButtons();
            }

        }

        private void ProceedMain()
        {
            //start scheduled model

            ReminderPage rp = new ReminderPage();
            this.Content = rp;

        }

        private void goBackButton_Click(object sender, RoutedEventArgs e)
        {
            textQuestion.Text = questions[--questionIndex];
            
            UpdateButtons();
        }
    }
}

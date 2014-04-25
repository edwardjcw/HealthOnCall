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
    public sealed partial class ReminderPage : Page
    {
        public ReminderPage()
        {
            this.InitializeComponent();
        }

        public ReminderPage(Reminder r) //temp (to remove)
        {

            this.InitializeComponent();
            reminderImage.Source = ImageID.GetImage(r.GetPictureID());
            reminderText.Text = r.GetTitle();
        }


        private void settingsButton_Click(object sender, RoutedEventArgs e)
        {
            SettingsPage sp = new SettingsPage();
            this.Content = sp;
        }
    }
}

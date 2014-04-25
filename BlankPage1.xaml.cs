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
using Windows.UI;
using Windows.Media.Capture;
using Windows.UI.Xaml.Media.Imaging; // for BitmapImage
using Windows.Storage; // for FileAccessMode

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace HealthOnCall
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        private async void readyButton_Click(object sender, RoutedEventArgs e)
        {
            var ui = new CameraCaptureUI();
            ui.PhotoSettings.AllowCropping = false;
            var file = await ui.CaptureFileAsync(CameraCaptureUIMode.Photo);

            if (file != null)
            {
                var bitmap = new BitmapImage();
                bitmap.SetSource(await file.OpenAsync(FileAccessMode.Read));
                var id = ImageID.NewImage(bitmap);
                AddReminder ar = new AddReminder(true);
                this.Content = ar;
            }
        }
    }
    public class ImageID
    {
        static int id = 0;
        static Dictionary<int, BitmapImage> dict = new Dictionary<int, BitmapImage>();
        public static int NewImage(BitmapImage x)
        {
            id = id + 1;
            dict.Add(id, x);
            return id;
        }
        public static int GetLastID()
        {
            return id;
        }
        public static BitmapImage GetImage(int x)
        {
            return dict[x];
        }
        //public static void Save()
        //{
        //    string file = "imageIDSave";
        //    BinaryWriter fs = 
        //}
        //public static void Load()
        //{

        //}
    }
}

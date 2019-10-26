using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPBingo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Track open app windows in a Dictionary.
        public static Dictionary<UIContext, AppWindow> AppWindows { get; set; }
            = new Dictionary<UIContext, AppWindow>();

        private DispatcherTimer dispatcherTimer;
        private Size screenSize;
        private const string ellipseName = "ellipseBingoNr";

        public MainPage()
        {
            this.InitializeComponent();
            this.LayoutDesign();
            Globals.ResetNumbers();

            //Init timer to start second screen
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            dispatcherTimer.Start();

            //Events
            Globals.BingoNrChanged += Globals_BingoNrChanged;
            Window.Current.SizeChanged += Current_SizeChanged;
        }

        private void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            object wantedItem = GridPage.FindName(ellipseName);
            if (wantedItem is Ellipse)
            {
                Ellipse ellipse = wantedItem as Ellipse;
                double newHeight = Window.Current.Bounds.Height;
                if(Window.Current.Bounds.Width < Window.Current.Bounds.Height)
                {
                    newHeight = Window.Current.Bounds.Width;
                }
                ellipse.Height = (newHeight / 2) - 10;
                ellipse.Width = ellipse.Height;
            }
        }

        private void Globals_BingoNrChanged(object sender, EventArgs e)
        {
            //Update current nr
            if (Globals.BingoNr == 0)
            {
                this.TxtBingoNr.Text = "";
            }
            else
            {
                this.TxtBingoNr.Text = Globals.BingoNr.ToString();
            }

            //Update history
            this.TxtHistory1.Text = (Globals.NumbersDone.Count >= 2) ?
               Globals.NumbersDone[1].ToString() : "";
            this.TxtHistory2.Text = (Globals.NumbersDone.Count >= 3) ?
               Globals.NumbersDone[2].ToString() : "";
            this.TxtHistory3.Text = (Globals.NumbersDone.Count >= 4) ?
                Globals.NumbersDone[3].ToString() : "";
        }

        private void DispatcherTimer_Tick(object sender, object e)
        {
            dispatcherTimer.Stop();
            dispatcherTimer.Tick -= DispatcherTimer_Tick;

            CreateSecondScreen();
        }

        private async void CreateSecondScreen()
        {
            // Create a new window.
            AppWindow appWindow = await AppWindow.TryCreateAsync();

            // Create a Frame and navigate to the Page you want to show in the new window.
            Frame appWindowContentFrame = new Frame();
            appWindowContentFrame.Navigate(typeof(AppWindowPage));

            // Attach the XAML content to the window.
            ElementCompositionPreview.SetAppWindowContent(appWindow, appWindowContentFrame);

            // Add the new page to the Dictionary using the UIContext as the Key.
            AppWindows.Add(appWindowContentFrame.UIContext, appWindow);
            appWindow.Title = "App Window " + AppWindows.Count.ToString();

            // When the window is closed, be sure to release
            // XAML resources and the reference to the window.
            appWindow.Closed += delegate
            {
                MainPage.AppWindows.Remove(appWindowContentFrame.UIContext);
                appWindowContentFrame.Content = null;
                appWindow = null;
            };

            // Show the window.
            await appWindow.TryShowAsync();
        }

        private void LayoutDesign()
        {
            //Screen bounds 
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            screenSize = new Size(bounds.Width * scaleFactor, bounds.Height * scaleFactor);

            Ellipse ellipse = new Ellipse();
            ellipse.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
            ellipse.Name = ellipseName;
            ellipse.Height = (Window.Current.Bounds.Height / 2) - 10;
            ellipse.Width = ellipse.Height;
            ellipse.HorizontalAlignment = HorizontalAlignment.Center;
            ellipse.VerticalAlignment = VerticalAlignment.Center;
            GridPage.Children.Add(ellipse);
            Canvas.SetZIndex(ellipse, 1);
            Grid.SetColumn(ellipse, 1);
            Grid.SetRow(ellipse, 1);
        }
    }
}


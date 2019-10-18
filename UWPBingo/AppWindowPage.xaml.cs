using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPBingo
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppWindowPage : Page
    {
        private Random rng = new Random();
        private SolidColorBrush CellActiveColor = new SolidColorBrush(Color.FromArgb(255, 255, 0, 221));

        public AppWindowPage()
        {
            this.InitializeComponent();
            this.SizeChanged += AppWindowPage_SizeChanged;
        }

        private void AppWindowPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

        private void BtnNextNumber_Click(object sender, RoutedEventArgs e)
        {
            int number = rng.Next(1, Globals.HighestNumber);
            string name = $"Row{number / 10}Col{number % 10}";
            TextBlock txt = this.FindName(name) as TextBlock;

            SetColorInCell(number);

        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NumberGrid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void SetColorInCell(int Number)
        {
            switch(Number)
            {
                case 1: this.border01.Background = CellActiveColor; break;
                case 2: this.border02.Background = CellActiveColor; break;
                case 3: this.border03.Background = CellActiveColor; break;
                case 4: this.border04.Background = CellActiveColor; break;

                default: break;
            }
        }
    }
}

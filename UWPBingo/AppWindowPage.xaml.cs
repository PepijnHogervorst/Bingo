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
                case 5: this.border05.Background = CellActiveColor; break;
                case 6: this.border06.Background = CellActiveColor; break;
                case 7: this.border07.Background = CellActiveColor; break;
                case 8: this.border08.Background = CellActiveColor; break;
                case 9: this.border09.Background = CellActiveColor; break;
                case 10: this.border10.Background = CellActiveColor; break;
                case 11: this.border11.Background = CellActiveColor; break;
                case 12: this.border12.Background = CellActiveColor; break;
                case 13: this.border13.Background = CellActiveColor; break;
                case 14: this.border14.Background = CellActiveColor; break;
                case 15: this.border15.Background = CellActiveColor; break;
                case 16: this.border16.Background = CellActiveColor; break;
                case 17: this.border17.Background = CellActiveColor; break;
                case 18: this.border18.Background = CellActiveColor; break;
                case 19: this.border19.Background = CellActiveColor; break;
                case 20: this.border20.Background = CellActiveColor; break;
                case 21: this.border21.Background = CellActiveColor; break;
                case 22: this.border22.Background = CellActiveColor; break;
                case 23: this.border23.Background = CellActiveColor; break;
                case 24: this.border24.Background = CellActiveColor; break;
                case 25: this.border25.Background = CellActiveColor; break;
                case 26: this.border26.Background = CellActiveColor; break;
                case 27: this.border27.Background = CellActiveColor; break;
                case 28: this.border28.Background = CellActiveColor; break;
                case 29: this.border29.Background = CellActiveColor; break;
                case 30: this.border30.Background = CellActiveColor; break;
                case 31: this.border31.Background = CellActiveColor; break;
                case 32: this.border32.Background = CellActiveColor; break;
                case 33: this.border33.Background = CellActiveColor; break;
                case 34: this.border34.Background = CellActiveColor; break;
                case 35: this.border35.Background = CellActiveColor; break;
                case 36: this.border36.Background = CellActiveColor; break;
                case 37: this.border37.Background = CellActiveColor; break;
                case 38: this.border38.Background = CellActiveColor; break;
                case 39: this.border39.Background = CellActiveColor; break;
                case 40: this.border40.Background = CellActiveColor; break;
                case 41: this.border41.Background = CellActiveColor; break;
                case 42: this.border42.Background = CellActiveColor; break;
                case 43: this.border43.Background = CellActiveColor; break;
                case 44: this.border44.Background = CellActiveColor; break;
                case 45: this.border45.Background = CellActiveColor; break;
                case 46: this.border46.Background = CellActiveColor; break;
                case 47: this.border47.Background = CellActiveColor; break;
                case 48: this.border48.Background = CellActiveColor; break;
                case 49: this.border49.Background = CellActiveColor; break;
                case 50: this.border50.Background = CellActiveColor; break;
                case 51: this.border51.Background = CellActiveColor; break;
                case 52: this.border52.Background = CellActiveColor; break;
                case 53: this.border53.Background = CellActiveColor; break;
                case 54: this.border54.Background = CellActiveColor; break;
                case 55: this.border55.Background = CellActiveColor; break;
                case 56: this.border56.Background = CellActiveColor; break;
                case 57: this.border57.Background = CellActiveColor; break;
                case 58: this.border58.Background = CellActiveColor; break;
                case 59: this.border59.Background = CellActiveColor; break;
                case 60: this.border60.Background = CellActiveColor; break;
                case 61: this.border61.Background = CellActiveColor; break;
                case 62: this.border62.Background = CellActiveColor; break;
                case 63: this.border63.Background = CellActiveColor; break;
                case 64: this.border64.Background = CellActiveColor; break;
                case 65: this.border65.Background = CellActiveColor; break;
                case 66: this.border66.Background = CellActiveColor; break;
                case 67: this.border67.Background = CellActiveColor; break;
                case 68: this.border68.Background = CellActiveColor; break;
                case 69: this.border69.Background = CellActiveColor; break;
                case 70: this.border70.Background = CellActiveColor; break;
                case 71: this.border71.Background = CellActiveColor; break;
                case 72: this.border72.Background = CellActiveColor; break;
                case 73: this.border73.Background = CellActiveColor; break;
                case 74: this.border74.Background = CellActiveColor; break;
                case 75: this.border75.Background = CellActiveColor; break;
                case 76: this.border76.Background = CellActiveColor; break;
                case 77: this.border77.Background = CellActiveColor; break;
                case 78: this.border78.Background = CellActiveColor; break;
                case 79: this.border79.Background = CellActiveColor; break;
                case 80: this.border80.Background = CellActiveColor; break;
                case 81: this.border81.Background = CellActiveColor; break;
                case 82: this.border82.Background = CellActiveColor; break;
                case 83: this.border83.Background = CellActiveColor; break;
                case 84: this.border84.Background = CellActiveColor; break;
                case 85: this.border85.Background = CellActiveColor; break;
                case 86: this.border86.Background = CellActiveColor; break;
                case 87: this.border87.Background = CellActiveColor; break;
                case 88: this.border88.Background = CellActiveColor; break;
                case 89: this.border89.Background = CellActiveColor; break;
                case 90: this.border90.Background = CellActiveColor; break;
                case 91: this.border91.Background = CellActiveColor; break;
                case 92: this.border92.Background = CellActiveColor; break;
                case 93: this.border93.Background = CellActiveColor; break;
                case 94: this.border94.Background = CellActiveColor; break;
                case 95: this.border95.Background = CellActiveColor; break;
                case 96: this.border96.Background = CellActiveColor; break;
                case 97: this.border97.Background = CellActiveColor; break;
                case 98: this.border98.Background = CellActiveColor; break;
                case 99: this.border99.Background = CellActiveColor; break;
                case 100: this.border100.Background = CellActiveColor; break;


                default: break;
            }
        }
    }
}

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
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPBingo
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppWindowPage : Page
    {
        public AppWindowPage()
        {
            this.InitializeComponent();
            this.SizeChanged += AppWindowPage_SizeChanged;
        }

        private void AppWindowPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawGrid();
        }

        private void BtnNextNumber_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NumberGrid_Loaded(object sender, RoutedEventArgs e)
        {
            DrawGrid();
        }

        private void DrawGrid()
        {
            DrawHorizontalLine(lineH1, 1);
            DrawHorizontalLine(lineH2, 2);
            DrawHorizontalLine(lineH3, 3);
            DrawHorizontalLine(lineH4, 4);
            DrawHorizontalLine(lineH5, 5);
            DrawHorizontalLine(lineH6, 6);
            DrawHorizontalLine(lineH7, 7);
            DrawHorizontalLine(lineH8, 8);
            DrawHorizontalLine(lineH9, 9);

            DrawVerticalLine(lineV1, 1);
            DrawVerticalLine(lineV2, 2);
            DrawVerticalLine(lineV3, 3);
            DrawVerticalLine(lineV4, 4);
            DrawVerticalLine(lineV5, 5);
            DrawVerticalLine(lineV6, 6);
            DrawVerticalLine(lineV7, 7);
            DrawVerticalLine(lineV8, 8);
            DrawVerticalLine(lineV9, 9);
        }

        private void DrawHorizontalLine(Line line, int position)
        {
            line.X1 = 0;
            line.X2 = this.NumberGrid.ActualWidth;
            line.Y1 = this.NumberGrid.ActualHeight / 10 * position;
            line.Y2 = line.Y1;
        }

        private void DrawVerticalLine(Line line, int position)
        {
            line.X1 = this.NumberGrid.ActualWidth / 10 * position;
            line.X2 = line.X1;
            line.Y1 = 0;
            line.Y2 = this.NumberGrid.ActualHeight;
        }

        
    }
}

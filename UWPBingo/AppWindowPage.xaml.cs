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

            LayoutDesign();
        }

        private void AppWindowPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }

        private void BtnNextNumber_Click(object sender, RoutedEventArgs e)
        {
            int number = rng.Next(1, Globals.HighestNumber);
            string name = $"Row{number / 10}Col{number % 10}";
            TextBlock txt = this.FindName(name) as TextBlock;

            //SetColorInCell(number);
            object wantedItem = GridPage.FindName("border" + number.ToString("D4"));
            if (wantedItem is Border)
            {
                Border border = wantedItem as Border;
                border.Background = new SolidColorBrush(Windows.UI.Colors.Green);
            }

        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NumberGrid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void LayoutDesign()
        {
            Border border;
            TextBlock textBlock;
            for (int i = 0; i < Globals.HighestNumber; i++)
            {
                border = new Border();
                border.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Gray);
                border.BorderThickness = new Thickness(2);
                border.Name = "border" + i.ToString("D4");
                GridPage.Children.Add(border);
                Grid.SetColumn(border, (i % Globals.NrOfColumns) + 1);
                Grid.SetRow(border, i / Globals.NrOfColumns);

                textBlock = new TextBlock();
                textBlock.Name = "Nr" + i.ToString("D4");
                textBlock.FontSize = 25;
                textBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.Text = i.ToString();
                GridPage.Children.Add(textBlock);
                Grid.SetColumn(textBlock, (i % Globals.NrOfColumns) + 1);
                Grid.SetRow(textBlock, i / Globals.NrOfColumns);
            }
        }
    }
}

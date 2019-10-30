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

        private string borderName = "border";
        private string textNrName = "nr";

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
            //Get number from list 
            int index = rng.Next(0, Globals.NumbersRemaining.Count - 1);
            int number = Globals.NumbersRemaining[index];
            this.txtCurrentNr.Text = number.ToString();

            //Set border background to color
            object wantedItem = GridPage.FindName(borderName + number.ToString("D4"));
            if (wantedItem is Border)
            {
                Border border = wantedItem as Border;
                border.Background = new SolidColorBrush(Windows.UI.Colors.Blue);
            }

            wantedItem = GridPage.FindName(textNrName + number.ToString("D4"));
            if (wantedItem is TextBlock)
            {
                TextBlock text = wantedItem as TextBlock;
                text.FontWeight = Windows.UI.Text.FontWeights.Bold;
            }

            //Remove number from list / and add to numbersdone list
            Globals.NumbersRemaining.RemoveAt(index);
            Globals.NumbersDone.Insert(0, number);

            //If numbersdone list count bigger than 1 set this to history
            this.txtHistory1.Text = (Globals.NumbersDone.Count >= 2) ?
               Globals.NumbersDone[1].ToString() : "";
            this.txtHistory2.Text = (Globals.NumbersDone.Count >= 3) ?
               Globals.NumbersDone[2].ToString() : "";
            this.txtHistory3.Text = (Globals.NumbersDone.Count >= 4) ?
               Globals.NumbersDone[3].ToString() : "";
            if (Globals.NumbersDone.Count > 1)
            {
                wantedItem = GridPage.FindName(borderName + Globals.NumbersDone[1].ToString("D4"));
                if (wantedItem is Border)
                {
                    Border border = wantedItem as Border;
                    border.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                }
            }
            

            //Update mainpage number, this event also updates history numbers
            Globals.BingoNr = number;

            //Disable button if it was last number
            if (Globals.NumbersRemaining.Count == 0)
            {
                this.BtnNextNumber.IsEnabled = false;
            }
        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {
            object item;

            Globals.ResetNumbers();
            this.BtnNextNumber.IsEnabled = true;

            //Reset numbers on screen:
            for (int i = 0; i < Globals.HighestNumber; i++)
            {
                item = GridPage.FindName(textNrName + i.ToString("D4"));
                if (item is TextBlock)
                {
                    TextBlock text = item as TextBlock;
                    text.FontWeight = Windows.UI.Text.FontWeights.Normal;
                }
                item = GridPage.FindName(borderName + i.ToString("D4"));
                if (item is Border)
                {
                    Border text = item as Border;
                    text.Background = new SolidColorBrush(Windows.UI.Colors.Black);
                }
            }

            //Clear number history
            this.txtCurrentNr.Text = "";
            this.txtHistory1.Text = "";
            this.txtHistory2.Text = "";
            this.txtHistory3.Text = "";
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
                border.Name = borderName + (i + 1).ToString("D4");
                GridPage.Children.Add(border);
                Grid.SetColumn(border, (i % Globals.NrOfColumns) + 1);
                Grid.SetRow(border, i / Globals.NrOfColumns);

                textBlock = new TextBlock();
                textBlock.Name = textNrName + (i + 1).ToString("D4");
                textBlock.FontSize = 25;
                textBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.Text = (i + 1).ToString();
                GridPage.Children.Add(textBlock);
                Grid.SetColumn(textBlock, (i % Globals.NrOfColumns) + 1);
                Grid.SetRow(textBlock, i / Globals.NrOfColumns);
            }
        }
    }
}

using System;
using System.Collections.Generic;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPBingo
{
    public static class Globals
    {
        public static event EventHandler BingoNrChanged;

        public static int HighestNumber = 90;

        public static int NrOfColumns = 10;
        public static int NrOfRows = (HighestNumber + NrOfColumns - 1) / NrOfColumns;

        private static int bingoNr = 0;
        public static int BingoNr
        {
            get { return bingoNr; }
            set
            {
                if (bingoNr != value)
                {
                    bingoNr = value;
                    OnBingoNrChanged(new EventArgs());
                }
            }
        }

        public static int[] BingoNrHistory = new int[3];

        public static List<int> NumbersRemaining = new List<int>();
        public static List<int> NumbersDone = new List<int>();
        
        private static void OnBingoNrChanged(EventArgs e)
        {
            EventHandler handler = BingoNrChanged;
            handler?.Invoke(null, e);
        }

        public static void ResetNumbers()
        {
            NumbersRemaining.Clear();
            NumbersDone.Clear();

            for (int i = 0; i < HighestNumber; i++)
            {
                NumbersRemaining.Add(i + 1);
            }

            //Clear 
            BingoNr = 0;
        }
    }
}


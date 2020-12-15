using System;

namespace Day5
{
    public class Seat
    {
        public Seat(string boardingPass)
        {
            BoardingPass = boardingPass;
        }

        public int SeatId
        {
            get
            {
                var result = (Row * 8) + Column;
                return result;
            }
        }

        public int Column
        {
            get{
                var result = 0;
                var power = ColumnText.Length - 1;
                foreach (var letter in ColumnText )
                {
                    int binaryDigit = 999;
                    if(letter == 'L')
                    {
                        binaryDigit = 0;
                    }
                    if(letter == 'R')
                    {
                        binaryDigit = 1;
                    }

                    result += binaryDigit * Convert.ToInt32(Math.Pow(2,power));
                    power -= 1;
                }
                return result;
            }
        }

        public int Row
        {
            get{
                var result = 0;
                var power = RowText.Length - 1;
                foreach (var letter in RowText )
                {
                    int binaryDigit = 999;
                    if(letter == 'F')
                    {
                        binaryDigit = 0;
                    }
                    if(letter == 'B')
                    {
                        binaryDigit = 1;
                    }

                    result += binaryDigit * Convert.ToInt32(Math.Pow(2,power));
                    power -= 1;
                }
                return result;
            }
        }

        private readonly string BoardingPass;

        private string RowText
        {
            get
            {
                return BoardingPass.Substring(0,7);
            }
        }

        private string ColumnText
        {
            get
            {
                return BoardingPass.Substring(7);
            }
        }

    }
}
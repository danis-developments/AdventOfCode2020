using System;
using System.Collections.Generic;
using System.IO;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            using (var boardingPassFile = File.OpenText(filename))
            {
                var highestSeatId = 0;
                var seatIds = new List<int>();
                while(true)
                {
                    var boardingPass = boardingPassFile.ReadLine();
                    if(boardingPass == null)
                    {
                        break;
                    }
                    else
                    {
                        var seat = new Seat(boardingPass);
                        seatIds.Add(seat.SeatId);
                        if(seat.SeatId > highestSeatId)
                        {
                            highestSeatId = seat.SeatId;
                        }
                        //Console.WriteLine($"Row {seat.Row}, Column {seat.Column}, Seat ID {seat.SeatId}");
                    }
                }
                Console.WriteLine($"The Highest Seat ID is: {highestSeatId}");
                seatIds.Sort();
                for (int i = 1; i < seatIds.Count; i++)
                {
                    if(seatIds[i] - seatIds[i -1] == 2)
                    {
                        Console.WriteLine($"My SeatId is {seatIds[i] - 1}");
                        break;
                    }
                }
            }
        }
    }
}

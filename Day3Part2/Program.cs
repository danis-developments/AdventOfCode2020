using System;

namespace Day3Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            var _fname = "mapslice.txt";
            string[] lines = System.IO.File.ReadAllLines(@_fname);
            var mapWidth = lines[0].Length;
            int[] rises = {1,1,1,1,2};
            int[] runs = {1,3,5,7,1};
            ulong result = 1;
            var numSlopes = rises.Length;
            for (int i = 0; i < numSlopes; i++)
            {
                var x = 0;
                var y = 0;
                var rise = rises[i];
                var run = runs[i];
                var loopLength = lines.Length / rise;
                uint numTrees = 0;
                
                for (int j = 0; j < loopLength; j++)
                {
                    char tree = '#';
                    if(lines[y][x%mapWidth] == tree)
                    {
                        numTrees++;
                    }
                    x += run;
                    y += rise;
                }
                result *= numTrees;
            }
            Console.WriteLine($"The result is {result}");
        }
    }
}

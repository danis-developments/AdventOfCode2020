using System;

namespace Day3Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var _fname = "mapslice.txt";
            string[] lines = System.IO.File.ReadAllLines(@_fname);
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var accumulator = "";
                for (int j = 0; j < 32; j++)
                {
                    accumulator += line;
                }
                lines[i] = accumulator;         
            }
            Console.WriteLine($"we have {lines.Length} lines of {lines[0].Length} length");
            var rise = 1;
            var run = 3;
            var x = 0;
            var y = 0;
            var numTrees = 0;
            var loopLength = lines.Length / rise;
            char tree = '#';
            if(lines[y][x] == tree){
                numTrees++;
            }
            for (int i = 0; i < loopLength; i++)
            {
                if(lines[y][x] == tree){
                    numTrees++;
                }
                y += rise;
                x += run;
            } 
            Console.WriteLine($"Number of trees we hit on the way down is {numTrees}");
        }
    }
}

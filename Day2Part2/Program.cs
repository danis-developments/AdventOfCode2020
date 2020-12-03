using System;

namespace Day2Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var _fname = "input.txt";

            string[] lines = System.IO.File.ReadAllLines(@_fname);

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine($"Contents of {_fname} = ");
            var validPasswords = 0;
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                bool validPassword = false;
                int firstPos;
                int secondPos;
                int dashPos = line.IndexOf("-");
                bool v = Int32.TryParse(line.Substring(0,dashPos), out firstPos);
                v = Int32.TryParse(line.Substring(dashPos + 1,line.IndexOf(" ") - dashPos), out secondPos);
                char policyChar = line[line.IndexOf(":")-1];
                var password = line.Substring(line.IndexOf(":") + 1).Trim();
                if((firstPos - 1 <= password.Length) & (secondPos - 1 <= password.Length))
                {
                    validPassword = (password[firstPos-1] == policyChar) ^ (password[secondPos-1] == policyChar);
                }
                else
                {
                    validPassword = false;
                }
                if(validPassword)
                {
                    validPasswords++;
                }
                
            }
            Console.WriteLine($"Number of Valid Passwords: {validPasswords}");
        } 

    }
}

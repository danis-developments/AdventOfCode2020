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
                int min;
                int max;
                int dashPos = line.IndexOf("-");
                bool v = Int32.TryParse(line.Substring(0,dashPos), out min);
                v = Int32.TryParse(line.Substring(dashPos + 1,line.IndexOf(" ") - dashPos), out max);
                char policyChar = line[line.IndexOf(":")-1];
                var password = line.Substring(line.IndexOf(":") + 1).Trim();
                Console.WriteLine(min + "-" + max + " " + policyChar + ":" + password);
                var totalPolicyChars = 0;
                foreach (var letter in password)
                {
                    if(letter == policyChar)
                    {
                        totalPolicyChars++;
                    }
                }
                validPassword = (totalPolicyChars >= min) & (totalPolicyChars <= max);
                if(validPassword)
                {
                    validPasswords++;
                }
                
            }
            Console.WriteLine($"Number of Valid Passwords: {validPasswords}");
        } 

    }
}

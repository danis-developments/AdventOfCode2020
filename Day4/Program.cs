using System;
using System.Collections.Generic;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            var passports = GetPassports(filename);
            var validPassports = 0;
            var strictValidPassports = 0;
            foreach(var passport in passports)
            {
                if(passport.ValidPassport)
                {
                    validPassports += 1;
                }
                if(passport.StrictValidPassport)
                {
                    strictValidPassports += 1;
                }
            }
            Console.WriteLine($"Number of valid passports is: {validPassports}");
            Console.WriteLine($"Number of strict valid passports is: {strictValidPassports}");
        }

        private static List<Passport> GetPassports(string filename)
        {
            var passportList = new List<Passport>();
            using (var inputFile = File.OpenText(filename))
            {
                bool done = false;
                while (!done)
                {
                    var passportData = "";
                    while (true)
                    {
                        var line = inputFile.ReadLine();
                        if (line == null)
                        {
                            done = true;
                            break;
                        }
                        else if (line == "")
                        {
                            break;
                        }
                        else
                        {
                            if (passportData == "")
                            {
                                passportData += line;
                            }
                            else
                            {
                                passportData += " " + line;
                            }
                        }
                    }
                    passportList.Add(new Passport(passportData));
                }
            }
            return passportList;
        }
    }
}

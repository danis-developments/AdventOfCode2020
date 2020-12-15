using System;

namespace Day4
{
    public class Passport
    {
        public int BirthYear
        {
            get;
            private set;
        }
        public int IssueYear
        {
            get;
            private set;
        }
        public int ExpirationYear
        {
            get;
            private set;
        }
        public string Height
        {
            get;
            private set;
        }
        public string HairColor
        {
            get;
            private set;
        }
        public string EyeColor
        {
            get;
            private set;
        }
        public string PassportId
        {
            get;
            private set;
        }
        public string CountryId
        {
            get;
            private set;
        }

        private const string DEFAULT_STRING_VALUE = "Not Set";

        public bool ValidPassport
        {
            get
            {
                if( BirthYear != 0 &&
                    IssueYear != 0 &&
                    ExpirationYear != 0 &&
                    Height != DEFAULT_STRING_VALUE &&
                    HairColor != DEFAULT_STRING_VALUE &&
                    EyeColor != DEFAULT_STRING_VALUE &&
                    PassportId != DEFAULT_STRING_VALUE) 
                {
                    return true;
                }
                return false;
            }
        }

        public bool StrictValidPassport
        {
            get
            {
                if( ValidBirthYear &&
                    ValidIssueYear &&
                    ValidExpirationYear &&
                    ValidHeight &&
                    ValidHairColor &&
                    ValidEyeColor &&
                    ValidPassportId) 
                {
                    return true;
                }
                return false;
            }
        }

        public bool ValidBirthYear 
        { 
            get
            {
                if(BirthYear >= 1920 && BirthYear <= 2002)
                {
                    return true;
                }
                return false;
            }
        }

        public bool ValidIssueYear 
        { 
            get
            {
                if(IssueYear >= 2010 && IssueYear <= 2020)
                {
                    return true;
                }
                return false;
            }
        }

        public bool ValidExpirationYear 
        { 
            get
            {
                if(ExpirationYear >= 2020 && ExpirationYear <= 2030)
                {
                    return true;
                }
                return false;
            }
        }

        public bool ValidHeight 
        { 
            get
            {
                if(Height.EndsWith("cm"))
                {
                    var numericHeight = Int32.Parse(Height.Substring(0,Height.Length - 2));
                    if(numericHeight >= 150 && numericHeight <= 193)
                    {
                        return true;
                    }
                } 
                else if(Height.EndsWith("in"))
                {
                    var numericHeight = Int32.Parse(Height.Substring(0,Height.Length - 2));
                    if(numericHeight >= 59 && numericHeight <= 76)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool ValidHairColor 
        { 
            get
            {
                bool result = true;
                if(HairColor.Length != 7 || !HairColor.StartsWith('#'))
                {
                    return false;
                }
                else
                {
                    for (int i = 1; i < HairColor.Length; i++)
                    {
                        char c = HairColor[i];
                        if((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f'))
                        {
                            // nothing, this character is good.
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public bool ValidEyeColor 
        { 
            get
            {
                string[] validEyeColors = {"amb","blu","brn","gry","grn","hzl","oth"};
                foreach(var color in validEyeColors)
                {
                    if(color == EyeColor)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public bool ValidPassportId
        { 
            get
            {
                if(PassportId.Length != 9)
                {
                    return false;
                }
                else
                {
                    foreach (char c in PassportId)
                    {
                        if((c >= '0' && c <= '9'))
                        {
                            // nothing, this character is good.
                        }
                        else
                        {
                            return false;
                        }                        
                    }
                }
                return true;
            }
        }


        public Passport(string data)
        {
            BirthYear = ParseBirthYear(data);
            IssueYear = ParseIssueYear(data);
            ExpirationYear = ParseExpirationYear(data);
            Height = ParseHeight(data);
            HairColor = ParseHairColor(data);
            EyeColor = ParseEyeColor(data);
            PassportId = ParsePassportId(data);
            CountryId = ParseCountryId(data);
        }

        private string GetDataValue(string data, string key)
        {
            var result = "";
            string[] fields = data.Split(' ');
            foreach(var field in fields)
            {
                if(field.StartsWith(key))
                {
                    result = field.Substring(key.Length + 1);
                }
            }
            return result;
        }

        private int ParseBirthYear(string data)
        {
            var result = 0;
            var birthYearString = GetDataValue(data, "byr");
            if(birthYearString != "")
            {
                result = Int32.Parse(birthYearString);
            }
            return result;
        }

        private int ParseIssueYear(string data)
        {
            var result = 0;
            var issueYearString = GetDataValue(data, "iyr");
            if(issueYearString != "")
            {
                result = Int32.Parse(issueYearString);
            }
            return result;
        }

        private int ParseExpirationYear(string data)
        {
            var result = 0;
            var expirationYearString = GetDataValue(data, "eyr");
            if(expirationYearString != "")
            {
                result = Int32.Parse(expirationYearString);
            }
            return result;
        }

        private string ParseHeight(string data)
        {
            var result = DEFAULT_STRING_VALUE;
            var heightString = GetDataValue(data, "hgt");
            if(heightString != "")
            {
                result = heightString;
            }
            return result;
        }

        private string ParseHairColor(string data)
        {
            var result = DEFAULT_STRING_VALUE;
            var hairColorString = GetDataValue(data, "hcl");
            if(hairColorString != "")
            {
                result = hairColorString;
            }
            return result;
        }

        private string ParseEyeColor(string data)
        {
            var result = DEFAULT_STRING_VALUE;
            var eyeColorString = GetDataValue(data, "ecl");
            if(eyeColorString != "")
            {
                result = eyeColorString;
            }
            return result;
        }

        private string ParsePassportId(string data)
        {
            var result = DEFAULT_STRING_VALUE;
            var passportIdString = GetDataValue(data, "pid");
            if(passportIdString != "")
            {
                result = passportIdString;
            }
            return result;
        }

        private string ParseCountryId(string data)
        {
            var result = DEFAULT_STRING_VALUE;
            var countryIdString = GetDataValue(data, "cid");
            if(countryIdString != "")
            {
                result = countryIdString;
            }
            return result;
        }

    }
}
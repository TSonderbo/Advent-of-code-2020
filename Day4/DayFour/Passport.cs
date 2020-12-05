using System;
using System.Collections.Generic;
using System.Text;

namespace DayFour
{
    public class Passport
    {
        public string ecl { get; set; }
        public string pid { get; set; }
        public string hcl { get; set; }
        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string cid { get; set; }

        public bool isValid()
        {
            return ecl != null && pid != null && hcl != null
                && byr != null && iyr != null && eyr != null
                && hgt != null;
        }

        public bool isSuperValid()
        {
            if(isValid())
            {
                try
                {
                    int byrInt = Int32.Parse(byr);
                    bool byrVaild = (byrInt >= 1920 && byrInt <= 2002);

                    int iyrInt = Int32.Parse(iyr);
                    bool iyrVaild = (iyrInt >= 2010 && iyrInt <= 2020);

                    int eyrInt = Int32.Parse(eyr);
                    bool eyrVaild = (eyrInt >= 2020 && eyrInt <= 2030);

                    bool hgtValid = false;
                    if(hgt.EndsWith("cm"))
                    {
                        string str = hgt.Remove(hgt.Length - 2);
                        int strParsed = Int32.Parse(str);
                        hgtValid = strParsed >= 150 && strParsed <= 193;
                    }
                    else if(hgt.EndsWith("in"))
                    {
                        string str = hgt.Remove(hgt.Length - 2);
                        int strParsed = Int32.Parse(str);
                        hgtValid = strParsed >= 59 && strParsed <= 76;
                    }
                    bool hclValid = false;
                    char[] hclChar = hcl.ToCharArray();
                    if(hcl[0] == '#')
                    {
                        for(int i = 1; i < hcl.Length; i++)
                        {
                            if(!((hclChar[i] <= 57 && hclChar[i] >= 48)
                                || (hclChar[i] >= 97 && hclChar[i] <= 102)))
                            {
                                break;
                            }
                        }
                        hclValid = true;
                    }
                    bool eclValid = ecl == "amb" || ecl == "blu" || ecl == "brn"|| 
                        ecl == "gry" || ecl == "grn" || ecl == "hzl" || ecl == "oth";
                    Int32.Parse(pid);
                    bool pidValid = pid.Length == 9;

                    return byrVaild && iyrVaild && eyrVaild && hgtValid && hclValid && eclValid && pidValid;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            return false;
        }
    }
}

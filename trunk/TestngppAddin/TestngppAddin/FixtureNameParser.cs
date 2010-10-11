using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TestngppAddin
{
    public class FixtureNameParser
    {
        const string pattern = @"^\s*FIXTURE\s*\(\s*([^, ]*)\s*,?\s*(.*?)\s*\)\s*$";
        Regex regex = new Regex(pattern);

        public string parse(string line)
        {
            if (!regex.IsMatch(line))
            {
                return "";
            }

            Match m = regex.Match(line);
            string name = m.Groups[1].Value;
            string description = m.Groups[2].Value;

            if (description != "")
            {
                return name + "[" + description + "]";
            }
            return name;
        }
    }
}

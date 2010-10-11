using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TestngppAddin
{
    public class AnnotationParser
    {
        string _id;
        string _depends;
        string _tags;
        string _data;

        public string id
        {
            get 
            {
                return _id;
            }
        }
        public string depends
        {
            get
            {
                return _depends;
            }
        }
        public string tags
        {
            get
            {
                return _tags;
            }
        }
        public string data
        {
            get
            {
                return _data;
            }
        }
        const string pattern = "^\\s*//\\s*@\\s*test\\s*\\("
            +"(\\s*id\\s*=\\s*([^, ]*)[,\\s]*"
            +"|\\s*depends\\s*=\\s*([^, ]*)[,\\s]*"
            +"|\\s*tags\\s*=\\s*(\".*\")[,\\s]*"
            +"|\\s*data\\s*=\\s*(\".*\")[,\\s]*)*\\)\\s*$";
        Regex regex = new Regex(pattern);
        public bool parse(string line)
        {
            if (!regex.IsMatch(line))
            {
                return false;
            }

            Match m = regex.Match(line);
            _id = m.Groups[2].Value;
            _depends = m.Groups[3].Value;
            _tags = m.Groups[4].Value;
            _data = m.Groups[5].Value;

            return true;
        }
    }
}

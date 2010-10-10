using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TestngppAddin
{
    struct TestInfo
    {
        string name;
        string id;
        string depends;
    }

    /// <summary>
    /// 解析一个用例的信息
    /// </summary>
    public class TestInfoParser
    {
        int parse(string input)
        {
            return 0;
        }

        /// <summary>
        /// ////////////
        /// </summary>
        const string testRegEx = @"(//\s*@test\((.*?)\))?\s*P?TEST\((.*?)\)";
        Regex regex = new Regex(testRegEx);
        MatchCollection mc;

        


        public int parse1()
        {
            string assist;
            string name;

            mc = regex.Matches("input");

            foreach (Match m in mc)
            {
                assist = m.Groups[2].Value;
                name = m.Groups[3].Value;

                Console.WriteLine(assist);
                Console.WriteLine(name);
            }

            return 1;
        }
        

    }
}

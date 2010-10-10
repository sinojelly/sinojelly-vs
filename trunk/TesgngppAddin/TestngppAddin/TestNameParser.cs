using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TestngppAddin
{
    /// <summary>
    /// 测试用例名解析器
    /// </summary>
    public class TestNameParser
    {
        struct Pattern
        {
            public string pattern;
            public int group;

            public Pattern(string _pattern, int _group)
            {
                pattern = _pattern;
                group = _group;
            }
        }

        List<Pattern> patternList = new List<Pattern>();

        public TestNameParser()
        {
            patternList.Add(new Pattern(@"^\s*TEST\((.*)\)\s*$", 1));
            patternList.Add(new Pattern(@"^\s*PTEST\(\s*\(.*?\)\s*,\s*(.*)\)\s*$", 1));
        }

        /// <summary>
        /// 解析输入的一行文本，匹配是否TEST或者PTEST
        /// </summary>
        /// <param name="line">输入的一行代码文本信息</param>
        /// <returns></returns>
        public string parse(string line)
        {
            foreach (Pattern pattern in patternList)
            {
                string result = match(pattern, line);
                if (string.Empty != result)
                {
                    return result;
                }
            }

            return string.Empty;

            /*
            const string testNameRegEx = @"^\s*TEST\((.*)\)\s*$";
            Regex testRegex = new Regex(testNameRegEx);

            Match m = testRegex.Match(line);

            if (string.Empty != m.Value)
            {
                return m.Groups[1].Value;
            }

            const string ptestNameRegEx = @"^\s*PTEST\(\s*\(.*?\)\s*,\s*(.*)\)\s*$";
            Regex ptestRegex = new Regex(ptestNameRegEx);

            Match pm = ptestRegex.Match(line);

            Group g = pm.Groups[1]; 

            return g.Value;*/
        }

        private string match(Pattern pattern, string line)
        {
            Regex regex = new Regex(pattern.pattern);

            Match m = regex.Match(line);

            Group g = m.Groups[pattern.group];

            return g.Value;
        }
    }
}

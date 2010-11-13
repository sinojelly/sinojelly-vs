using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace TestngppAddin
{
    struct TestInfo
    {
        string name;
        string id;
        string depends;
    }

    class FixtureInfo
    {
        public string name;
        public int index;
    }

    class Fixture
    {
        private List<FixtureInfo> fixtures;
        
        public string this[int index]
        {
            get
            {
                for (int i = 0; i < index; i++)
                {
                
                }
                return fixtures.
            }
        }
    }

    /// <summary>
    /// 解析一个用例的信息
    /// </summary>
    public class TestInfoParser
    {
        public Fixture Fixtures;

        public bool parse(Stream stream)
        {
            int count = 0;
            string line;
            using (StreamReader sr = new StreamReader(stream))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    count++;
                }
            }
            return true;
        }
    }
}

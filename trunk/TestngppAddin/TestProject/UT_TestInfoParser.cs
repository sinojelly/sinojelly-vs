using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestngppAddin;
using System.IO;

namespace TestProject1
{
    [TestClass]
    public class UT_TestInfoParser
    {
        TestInfoParser parser = new TestInfoParser();

        [TestMethod]
        public void mem_stream_parser()
        {
            string multiLines = "a\nb\nc";            ;
            MemoryStream stream = new MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(multiLines));
            Assert.AreEqual(3, parser.parse(stream));
        }

        [TestMethod]
        public void file_stream_parser()
        {
            string multiLines = "a\r\nb\r\nc"; //"a\nb\nc"也可以
#if true
            using (StreamWriter w = new StreamWriter("just_test.txt")) // using会自动关闭文件，是推荐的使用方式
            {
                w.Write(multiLines);
            }
#else
            StreamWriter w = new StreamWriter("just_test.txt");
            w.Write(multiLines);
            w.Close(); // 如果不用using，必须有这句话手动关闭文件
#endif
            FileStream stream = new FileStream("just_test.txt", FileMode.Open);
            Assert.AreEqual(3, parser.parse(stream));
        }
    }
}

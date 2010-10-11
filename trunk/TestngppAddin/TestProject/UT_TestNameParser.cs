using TestngppAddin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for TestNameParserTest and is intended
    ///to contain all TestNameParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UT_TestNameParser
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        TestNameParser target = new TestNameParser(); 

        [TestMethod()]
        public void line_is_empty()
        {            
            Assert.AreEqual(string.Empty, target.parse(string.Empty));
        }

        [TestMethod()]
        public void line_is_null_string()
        {
            Assert.AreEqual(string.Empty, target.parse(""));
        }

        [TestMethod()]
        public void line_is_english_name_test()
        {
            string name = "english test name";
            Assert.AreEqual(name, target.parse("    TEST("+name+")"));
        }

        [TestMethod()]
        public void line_is_chinese_name_test()
        {
            string name = "这是一个 中文用例名";
            Assert.AreEqual(name, target.parse("    TEST("+name+")"));
        }

        [TestMethod()]
        public void line_is_parametered_test()
        {
            string name = "this is a parametered() test";
            Assert.AreEqual(name, target.parse("    PTEST( (const char* name), "+name+")"));
        }
    }
}

/*
 TODO: PTEST要显示为多个用例，采用  用例名_Parameter(p1, p2)  的方式。(暂时不做)
 */
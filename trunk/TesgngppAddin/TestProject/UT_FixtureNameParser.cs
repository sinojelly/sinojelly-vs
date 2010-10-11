using TestngppAddin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for FixtureNameParserTest and is intended
    ///to contain all FixtureNameParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UT_FixtureNameParser
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

        FixtureNameParser parser = new FixtureNameParser();

        /// <summary>
        ///A test for parse
        ///</summary>
        [TestMethod()]
        public void only_fixture_class()
        {
            Assert.AreEqual("TestClass", parser.parse("FIXTURE(TestClass)"));
        }

        [TestMethod()]
        public void with_description()
        {
            Assert.AreEqual("TestClass[这是描述]", parser.parse("FIXTURE(TestClass , 这是描述)"));
        }

        [TestMethod()]
        public void with_some_spaces()
        {
            Assert.AreEqual("TestClass[这是 描述]", parser.parse(" FIXTURE ( TestClass , 这是 描述 ) "));
        }
    }
}

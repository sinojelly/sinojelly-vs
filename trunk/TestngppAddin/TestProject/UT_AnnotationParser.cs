using TestngppAddin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for AnnotationParserTest and is intended
    ///to contain all AnnotationParserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UT_AnnotationParser
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

        AnnotationParser parser = new AnnotationParser();

        /// <summary>
        ///A test for parse
        ///</summary>
        [TestMethod()]
        public void only_test_id()
        {
            string id = "test-id";
            Assert.AreEqual(true, parser.parse("  // @ test ( id = "+id+" )"));
            Assert.AreEqual(id, parser.id);
        }

        [TestMethod()]
        public void with_id_depends_tags()
        {
            Assert.AreEqual(true, parser.parse("  // @ test ( id = test-id , depends = other-test , tags = \"ut it\" )"));
            Assert.AreEqual("test-id", parser.id);
            Assert.AreEqual("other-test", parser.depends);
            Assert.AreEqual("\"ut it\"", parser.tags);
        }

        [TestMethod()]
        public void with_depends_tags_id()
        {
            Assert.AreEqual(true, parser.parse("  // @ test ( depends = other-test , tags = \"ut it\" ,id = test-id)"));
            Assert.AreEqual("test-id", parser.id);
            Assert.AreEqual("other-test", parser.depends);
            Assert.AreEqual("\"ut it\"", parser.tags);
        }

        [TestMethod()]
        public void line_is_empty()
        {
            Assert.AreEqual(false, parser.parse(""));
            Assert.AreEqual(false, parser.parse(string.Empty));
        }

        [TestMethod()]
        public void with_data_id_depends()
        {
            Assert.AreEqual(true, parser.parse("  // @ test (data=\"names\", id = test-id, depends = other-test )"));
            Assert.AreEqual("test-id", parser.id);
            Assert.AreEqual("other-test", parser.depends);
            Assert.AreEqual("\"names\"", parser.data);
        }
    }
}

/*
  Note: 注释解析
 * D:\Projects\Google\testngpp\test-ng-pp-read-write_svn\test-ng-pp\samples\TestBar.h
 * // @fixture(tags=succ)   fixture的tags有什么用?
 * // @test(data="names")
 * // @test(id=1)
 * // @test(depends=2, tags="ft slow empty")
 * // @test(id=4, depends=3, tags="it slow")
  TODO: #if 0或者注释掉的用例，最好能过滤掉。
 * 可以用一个C++有效代码提取模块，把注释、#if 0掉的代码过滤掉，然后再针对过滤后的有效代码进行处理。
 */
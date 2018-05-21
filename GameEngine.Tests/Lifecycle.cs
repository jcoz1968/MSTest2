using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Tests
{
    [TestClass]
    public class Lifecycle
    {
        static string SomeTestContext;

        [TestInitialize]
        public void LifecycleInit()
        {
            Console.WriteLine("        Initializing Lifecyle");
        }

        [TestCleanup]
        public void LifecycleClean()
        {
            Console.WriteLine("        Cleanup Lifecyle");
        }

        [ClassInitialize]
        public static void LifecyleClassInit(TestContext context)
        {
            Console.WriteLine("        Class Initialize Lifecyle");
            Console.WriteLine(" data loaded from disk");
            SomeTestContext = "42";
        }


        [TestMethod]
        public void TestA()
        {
            Console.WriteLine("        Test A starting");
            Console.WriteLine($"  Shared test context:  {SomeTestContext}");
        }

        [TestMethod]
        public void TestB()
        {
            Console.WriteLine("        Test B starting");
        }
    }
}

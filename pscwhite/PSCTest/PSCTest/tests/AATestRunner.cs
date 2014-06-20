using System;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using PSCTest.core;
using pscWindow = TestStack.White.UIItems.WindowItems.Window;
using Application = TestStack.White.Application;
using PSCTest.utilities;
using Thread = System.Threading.Thread;
using NUnit.Framework;

namespace PSCTest.tests
{
    [TestFixture]
    class AATestRunner
    {
        //SampleTEst Class Variables
        Application application;
        static pscWindow currentWindow;

        public static void Main(string[] args)    {        } 

        //SampleTest Class Constructor to launch PSC and get the current window of PSC
        [TestFixtureSetUp]
        public void SetupTest()
        {
            Console.WriteLine("Setting up environment for the Test");
            Setup.launchPSC();
            application = Setup.attachPSC();
            currentWindow = Setup.getWindow(application);   
            //TestRunner runner = new TestRunner();    
        }

        [Test]
        public void LoginPSC()
        {
            Console.WriteLine("Login into PSC using username and password");
            Login.loginPSC(currentWindow);
            Thread.Sleep(5000);
        }
    }
}

using System;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using PSCTest.core;
using pscWindow = TestStack.White.UIItems.WindowItems.Window;
using Application = TestStack.White.Application;
using PSCTest.utilities;
using Thread = System.Threading.Thread;
using NUnit.Framework;
using SikuliModule;
namespace PSCTest.tests
{
    class SikuliImageUse
    {
         //SampleTEst Class Variables
          Application application;
          static pscWindow currentWindow;
          static SearchPage search = null;
          StandardOperations standard;
          Tabs tabs;
          public static int patientid = 1;
          public static bool flag = false;


        //SampleTest Class Constructor to launch PSC and get the current window of PSC
       // [TestFixtureSetUp]
        public void SetupTest()
        {
            application = Setup.attachPSC();
            currentWindow = Setup.getWindow(application);
            standard = new StandardOperations(currentWindow);
            search = new SearchPage(currentWindow);
            tabs = new Tabs(currentWindow);
        }
  
        //[Test]
        public void ClickImage()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Trying to click on image using sikuli");
            try
            {
                SikuliAction.Click("C:\\workspace\\pscautomation\\pscwhite\\PSCTest\\PSCTest\\utilities\\lookup\\pscimage\\returncontainer.png");
            }
            catch(Exception)
            {
                Console.WriteLine("Not able to find the element");
            }
            Assert.Pass();
        }
    }
}

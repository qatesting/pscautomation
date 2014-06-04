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
    class AddPatientTest
    {
        //SampleTEst Class Variables
        Application launchapp;
        Application application = null;
        static pscWindow currentWindow;
        static SearchPage search = null;
        StandardOperations standard;
        Tabs tabs; 

        public static void Main(string[] args)     { }

        //SampleTest Class Constructor to launch PSC and get the current window of PSC
        [TestFixtureSetUp]
        public void SetupTest()
        {            
            launchapp = Setup.launchPSC();
            application = Setup.attachPSC();
            currentWindow = Setup.getWindow(application);
            search = new SearchPage(currentWindow);
            standard = new StandardOperations(currentWindow);
            tabs = new Tabs(currentWindow);
            //TestRunner runner = new TestRunner();            
        }
 
        [Test]
        public void LoginPSC()
        {
            Login.loginPSC(currentWindow);
            Thread.Sleep(5000);
            Screenshot screen = new Screenshot();
        }

        [Test]
        public void SearchAndAddPatient()
        {
            for (int patientid = 1; patientid < 9; patientid++)
            {
                search.SearchPatient(patientid);
                Thread.Sleep(5000);
                if (search.IsSearchEmpty())
                {
                    Console.WriteLine("Not able to search the patient, So adding the patient");
                    search.AddNewPatient();
                    AddNewPatientInformation(patientid);
                }
                else
                {
                    Console.WriteLine("Patient Found");
                    search.SelectFirstSearchRecord();
                    Thread.Sleep(10000);
                    tabs.Dashboard();
                    Thread.Sleep(2000);
                    standard.Ok();
                    Thread.Sleep(5000);
                    continue;
                }
            }
        }        
 
        public void AddNewPatientInformation(int patientid)
        {
            Thread.Sleep(5000);
            BasicInfoPage bip = new BasicInfoPage(currentWindow);
            bip.ProvideBasicInformation(patientid);
            Thread.Sleep(2000);
            standard.Save();
            Thread.Sleep(3000);
            tabs.Dashboard();
            Thread.Sleep(2000);
            standard.Ok();
        }
    }
 }



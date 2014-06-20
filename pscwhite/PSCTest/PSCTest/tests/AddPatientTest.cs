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
          Application application;
          static pscWindow currentWindow;
          static SearchPage search = null;
          StandardOperations standard;
          Tabs tabs;
          public static int patientid = 1;
          public static bool flag = false;


        //SampleTest Class Constructor to launch PSC and get the current window of PSC
        [TestFixtureSetUp]
        public void SetupTest()
        {
            application = Setup.attachPSC();
            currentWindow = Setup.getWindow(application);
            standard = new StandardOperations(currentWindow);
            search = new SearchPage(currentWindow);
            tabs = new Tabs(currentWindow);
        }  

        [SetUp]
        public void SearchPatient()
        {
            if (patientid < 3)
            {
                search.SearchPatient(patientid);
                Thread.Sleep(5000);
            }
            patientid++;
        }

        [Test]
        public void AddNonExistingPatient()
        {
            if (search.IsSearchEmpty() && patientid < 3)
            {
                Console.WriteLine("Not able to search the patient, So adding the patient");
                search.AddNewPatient();
                Thread.Sleep(5000);
                BasicInfoPage bip = new BasicInfoPage(currentWindow);
                bip.ProvideBasicInformation("patientadditionalinfo.csv", patientid);
                Thread.Sleep(2000);
                standard.Save();
                Thread.Sleep(3000);
                tabs.Dashboard();
                Thread.Sleep(2000);
                standard.Ok();
            }
        }

        [TearDown]
        public void OpenPatientInformation()
        {
            if (!search.IsSearchEmpty() && patientid < 3)
            {
                Console.WriteLine("Patient Found in PSC");
                search.SelectFirstSearchRecord();
                Thread.Sleep(10000);
                tabs.Dashboard();
                Thread.Sleep(2000);
                standard.Ok();
                Thread.Sleep(5000);
            }                
        } 
    }
 }



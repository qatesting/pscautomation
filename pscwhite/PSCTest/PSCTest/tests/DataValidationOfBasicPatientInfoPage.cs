using System;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using PSCTest.core;
using pscWindow = TestStack.White.UIItems.WindowItems.Window;
using Application = TestStack.White.Application;
using PSCTest.utilities;
using Thread = System.Threading.Thread;
using NUnit.Framework;
using System.Collections.Generic;

namespace PSCTest.tests
{
    class DataValidationOfBasicPatientInfoPage
    {
        //Sampletest Class Variables
        Application application;
        static pscWindow currentWindow;
        static SearchPage search = null;
        StandardOperations standard;
        Tabs tabs;
        BasicInfoPage bip;
        public static int count = 0;
        public static bool flag = false;
        int searchpatient = 3;
        string filename = "datavalidationbasicinfo.csv";

        //SampleTest Class Constructor to launch PSC and get the current window of PSC
        [TestFixtureSetUp]
        public void SetupTest()
        {
            application = Setup.attachPSC();
            currentWindow = Setup.getWindow(application);
            standard = new StandardOperations(currentWindow);
            search = new SearchPage(currentWindow);
            tabs = new Tabs(currentWindow);
            bip = new BasicInfoPage(currentWindow);
        }

        static int[] patientids = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 1 };
        
        //Searching for pateint
        public void SearchPatient()
        {
            //Searching for the patient
            search.SearchPatient(searchpatient);
            search.SelectFirstSearchRecord();
            bip.GoBackToBasicInfoPage();
            standard.Edit();
        }


      public void SearchingPatients(string info, int patientid)
      {
            Console.WriteLine("\n----------------------------------Test Started for " + info + " ----------------------------------------\n");
            Console.WriteLine("Validate " + info + " Test has been started for this patient --> " + patientid);
            if (count == 0)
                SearchPatient();
            if (flag)
                standard.Edit();
            Console.WriteLine("Step : Providing data in " + info + " field");
        }

        public bool ValidateInformation()
        {
            if (bip.VerifyBasicInfoField())
            {
                flag = true;
                Console.WriteLine("---------------------------------- TEST PASSED -------------------------------------------\n");
                Console.WriteLine("Result: Patient information able to save Test Passed");
                Console.WriteLine("\n--------------------------------------------------------------------------------\n");
                if (count == patientids.Length - 1)
                {
                    Console.WriteLine("All Test have been finished, Going to Dashboard");
                    Thread.Sleep(2000);
                    tabs.Dashboard();
                    Thread.Sleep(3000);
                    standard.Ok();
                    count = -1;
                }
                return flag;
            }
            else
            {
                flag = false;
                Console.WriteLine("\n-------------------------------------- TEST FAILED --------------------------------------------------");
                Console.WriteLine("Result: Patient information not able to save, Test Failed");
                Console.WriteLine("\n--------------------------------------------------------------------------------\n");
                if (count == patientids.Length - 1)
                {
                    Console.WriteLine("All Test have been finished, Going to Dashboard");
                    Thread.Sleep(2000);
                    tabs.Dashboard();
                    Thread.Sleep(3000);
                    standard.Ok();
                    count = -1;
                }
                return flag;
            }
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_Zip_Code_In_Basic_Info_Page(int patientid)
        {
            SearchingPatients("Zipcode",patientid);
            bip.ProvideZipCode(filename, patientid);
            flag = ValidateInformation();
            if (flag){
                 count++;
                 Assert.Pass();
            }
            else
            {
                count++;
                Assert.Fail();
            }                
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_First_Name_In_Basic_Info_Page(int patientid)
        {
            SearchingPatients("FirstName", patientid);
            bip.ProvideFirstName(filename, patientid);
            flag = ValidateInformation();
            if (flag)
            {
                count++;
                Assert.Pass();
            }
            else
            {
                count++;
                Assert.Fail();
            }
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_Middle_Name_In_Basic_Info_Page(int patientid)
        {
            SearchingPatients("Middle", patientid);
            bip.ProvideMiddleName(filename, patientid);
            flag = ValidateInformation();
            if (flag)
            {
                count++;
                Assert.Pass();
            }
            else
            {
                count++;
                Assert.Fail();
            }
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_Last_Name_In_Basic_Info_Page(int patientid)
        {
            SearchingPatients("LastName", patientid);
            bip.ProvideLastName(filename, patientid);
            flag = ValidateInformation();
            if (flag)
            {
                count++;
                Assert.Pass();
            }
            else
            {
                count++;
                Assert.Fail();
            }
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_DOB_In_Basic_Info_Page(int patientid)
        {
            SearchingPatients("Date Of Birth", patientid);
            bip.ProvideDOB(filename, patientid);
            flag = ValidateInformation();
            if (flag)
            {
                count++;
                Assert.Pass();
            }
            else
            {
                count++;
                Assert.Fail();
            }
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_Mobile_Phone_In_Basic_Info_Page(int patientid)
        {
            SearchingPatients("Mobile Phone", patientid);
            bip.ProvideMobilePhone(filename, patientid);
            flag = ValidateInformation();
            if (flag)
            {
                count++;
                Assert.Pass();
            }
            else
            {
                count++;
                Assert.Fail();
            }
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_HomePhone_In_Basic_Info_Page(int patientid)
        {
            SearchingPatients("Home Phone", patientid);
            bip.ProvideHomePhone(filename, patientid);
            flag = ValidateInformation();
            if (flag)
            {
                count++;
                Assert.Pass();
            }
            else
            {
                count++;
                Assert.Fail();
            }
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_Email_In_Basic_Info_Page(int patientid)
        {
            SearchingPatients("Email", patientid);
            bip.ProvideEmail(filename, patientid);
            flag = ValidateInformation();
            if (flag)
            {
                count++;
                Assert.Pass();
            }
            else
            {
                count++;
                Assert.Fail();
            }
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_Preferred_Method_Of_Communication_In_Basic_Info_Page(int patientid)
        {
            SearchingPatients("Preferred Method of Communication", patientid);
            bip.ProvidePreferedCommunication(filename, patientid);
            flag = ValidateInformation();
            if (flag)
            {
                count++;
                Assert.Pass();
            }
            else
            {
                count++;
                Assert.Fail();
            }
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_All_Patient_Basic_Info_Fields(int patientid)
        {
            SearchingPatients("Preferred Method of Communication", patientid);
            bip.ProvideFirstName(filename, patientid);
            bip.ProvideLastName(filename, patientid);
            bip.ProvideDOB(filename, patientid);
            bip.ProvideBasicInformation(filename, patientid);
            flag = ValidateInformation();
            if (flag)
            {
                count++;
                Assert.Pass();
            }
            else
            {
                count++;
                Assert.Fail();
            }
        }
    }   
}

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
    class DataValidationOfAdditionalInfoPage
    {
        //Sampletest Class Variables
        Application application;
        static pscWindow currentWindow;
        static SearchPage search = null;
        StandardOperations standard;
        AdditionalInfoPage aip;
        Tabs tabs;
        BasicInfoPage bip;
        public static int count = 0;
        public static bool flag = false;
        public static bool check = true;
        public static bool billing = false;
        int searchpatient = 3;
        string filename = "datavalidationadditionalinfo.csv";

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
            aip = new AdditionalInfoPage(currentWindow);

            //Searching for the patient
            search.SearchPatient(searchpatient);
            search.SelectFirstSearchRecord();
        }

        static int[] patientids = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 1};

        //Searching for pateint
        public void GoToAddtionalInfoPage(string info, int patientid)
        {
            Console.WriteLine("\n----------------------------------Test Started for " + info + " ----------------------------------------\n");
            Console.WriteLine("Validate " + info + " Test has been started for this patient --> " + patientid);
            aip.GoToAdditionalInfoPage();
            Console.WriteLine("Step : Providing data in " + info + " field");
        }

        //Validating information of each field
        public bool ValidateInformation()
        {
            if (aip.IsPatientAgeIsLessThen18Years())
            {
                Console.WriteLine("Need to Add the guardian first, So Adding the guardian before Passing the result");
                aip.AddGuardian(1);
                Console.WriteLine("Guardian Successfully Added for this patient");                
            }
            if ((aip.VerifyAdditionalInfoField()))
            {  
                flag = true;
                Console.WriteLine("***** TEST PASSED ****** \n");
                Console.WriteLine("Result: Patient address saved successfully, Test Passed");
                Console.WriteLine("\n-----------------------------------------------------------------------------------------\n");
                return flag;
            }
            else
            {
                flag = false;                
                Console.WriteLine("\n>>>>>>> TEST FAILED >>>>>>");
                Console.WriteLine("Result: Patient address not able to save, Test Failed");
                Console.WriteLine("\n--------------------------------------------------------------------------------------------\n");
                return flag;
            }
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_Mailing_Street_Address_In_Additional_Info_Page(int patientid)
        {
            GoToAddtionalInfoPage("Mailing Street Address", patientid);
            aip.ProvideMailingStreet(filename, patientid);
            flag = ValidateInformation();
            if (flag)
                Assert.Pass();
            else
                Assert.Fail();
         }        
        

        [Test, TestCaseSource("patientids")]
        public void Validate_Mailing_Zip_Code_In_Additional_Info_Page(int patientid)
        {
            GoToAddtionalInfoPage("Mailing Zipcode", patientid);
            aip.ProvideMailingZipCode(filename, patientid);
            flag = ValidateInformation();
            if (flag)
                Assert.Pass();
            else
                Assert.Fail();
       }

        [Test, TestCaseSource("patientids")]
        public void Validate_Mailing_City_In_Additional_Info_Page(int patientid)
        {
            GoToAddtionalInfoPage("Mailing City", patientid);
            aip.ProvideMailingCity(filename, patientid);
            flag = ValidateInformation();
            if (flag)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_Mailing_State_In_Additional_Info_Page(int patientid)
        {
            GoToAddtionalInfoPage("Mailing City", patientid);
            aip.ProvideMailingState(filename, patientid);
            flag = ValidateInformation();
            if (flag)
                Assert.Pass();
            else
                Assert.Fail();
        }

        public void BeforeBillingInformation(int patientid)
        {
            if (check)
                aip.SameAsMailingAddress();
            check = false;
            GoToAddtionalInfoPage("Billing Street Address", patientid);
            if(!billing)
                aip.ProvideBillingAddress(filename, patientid);
            billing = true;
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_Billing_Address_In_Additional_Info_Page(int patientid)
        {
            BeforeBillingInformation(patientid);
            aip.ProvideBillingAddress(filename, patientid);
            flag = ValidateInformation();
            if (flag)
                Assert.Pass();
            else
                Assert.Fail();

        }

        [Test, TestCaseSource("patientids")]
        public void Validate_Billing_Street_Address_In_Additional_Info_Page(int patientid)
        {
            BeforeBillingInformation(patientid);
            aip.ProvideBillingStreet(filename, patientid);
            flag = ValidateInformation();
            if (flag)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_Billing_Zip_Code_In_Additional_Info_Page(int patientid)
        {
            BeforeBillingInformation(patientid);
            GoToAddtionalInfoPage("Billing Zipcode", patientid);
            aip.ProvideBillingZipCode(filename, patientid);
            flag = ValidateInformation();
            if (flag)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_Billing_City_In_Additional_Info_Page(int patientid)
        {
            BeforeBillingInformation(patientid);
            GoToAddtionalInfoPage("Billing City", patientid);
            aip.ProvideBillingCity(filename, patientid);
            flag = ValidateInformation();
            if (flag)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test, TestCaseSource("patientids")]
        public void Validate_Billing_State_In_Additional_Info_Page(int patientid)
        {
            BeforeBillingInformation(patientid);
            GoToAddtionalInfoPage("Billing State", patientid);
            aip.ProvideBillingState(filename, patientid);
            flag = ValidateInformation();
            if (flag)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public void Before_Running_Test_Angainst_Billing_Address()
        {
            bip.GoBackToBasicInfoPage();
            standard.Next();
            Console.WriteLine("Verifying if SameAsMaillingAddressChecked is selected or not");
            check = aip.IsSameAsMailingAddressChecked(filename, 1);
            if (check){
                Console.WriteLine("SameAsMaillingAddress is already Check");
                Assert.Pass();
            }
            else
            {
                Console.WriteLine("SameAsMaillingAddress is not checked");
                Assert.Fail();
            }                          
        }       


        [TestFixtureTearDown]
        public void GoBackToDashBoard()
        {
            Console.WriteLine("All tests have been finished, Going back to DashBoard");
            Thread.Sleep(2000);
            tabs.Dashboard();
            Thread.Sleep(4000);
            standard.Ok();
        }    
    }
}

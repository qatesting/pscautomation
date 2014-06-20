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
    [TestFixture]
    class DuplicatePatientTest
    {
        //SampleTEst Class Variables
        Application application;
        static pscWindow currentWindow;
        static SearchPage search = null;
        static int count = -1;
        StandardOperations standard;
        Tabs tabs;
        BasicInfoPage bip;
        public static bool flag = false;
        string filename = "duplicatepatients.csv";
        

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

        static int[] patientids = new int[] { 1,2};

        [Test, TestCaseSource("patientids")]
        public void AddNonExistingPatient(int patientid)
        {
            flag = false;
            Console.WriteLine("------------Searching for the patient  "+patientid+" ------------");
            search.SearchPatient("duplicatepatients.csv", patientid);
            Thread.Sleep(5000);
            if (!search.IsSearchEmpty())
            {
                Console.WriteLine("Patient Found in PSC!!");
                tabs.Dashboard();
                flag = true;
                Console.WriteLine("---------------------------------------------------------------------------\n");
                Assert.Ignore("Result:  Ignoring this patient as this already exist in PSC");          
            }
            if (flag == false)
            {
                Console.WriteLine("Patient doesn't exist on PSC, So adding the patient");
                flag = bip.AddPatient(filename, patientid);
                Thread.Sleep(2000);
                if (!standard.Save())
                {
                    Console.WriteLine("Result:  Not able to add new patient as patient information is not correct in one or more basic info fields");
                    Console.WriteLine(" INFO:  Please check the screenshot for more information");
                    bip.GoToDashBoard();
                    Console.WriteLine("---------------------------------------------------------------------------\n");
                    Assert.Ignore();                    
                }
                Thread.Sleep(4000);
                flag = bip.VerifyPatientAdded();
                Thread.Sleep(2000);
                bip.GoToDashBoard();
                Assert.Pass();
            } 
        }

        [Test, TestCaseSource("patientids")]
        public void PSCNotAllowingToAddDuplicatePatient(int patientid)
        {
                Console.WriteLine("\n----------------------Testing Patient ID " +patientid+ "-------------------------------------\n");
                Console.WriteLine("TEST-----> Verify if PSC allow to add duplicate patient ");
                Console.WriteLine("Step1- Searching for the already added patient ");
                search.SearchPatient("duplicatepatients.csv", patientid);
                Thread.Sleep(5000);
                if (search.IsSearchEmpty())
                {
                    Console.WriteLine("Patient Not Found in PSC!!");
                    tabs.Dashboard();
                    flag = true;
                    Console.WriteLine("---------------------------------------------------------------------------\n");
                    Assert.Ignore("Result:  Ignoring this test as this patient doesn't exist in PSC");
                }
                Console.WriteLine("Step2: Patient already added in PSC, So trying to add duplicate patient in PSC");
                flag = bip.AddPatient(filename, patientid);
                Thread.Sleep(2000);
                if (!standard.Save())
                {
                    Console.WriteLine("Result:  Not able to add new patient as patient information is not correct in one or more basic info fields");
                    Console.WriteLine(" INFO:  Please check the screenshot for more information");
                    Thread.Sleep(2000);
                    bip.GoToDashBoard();
                    Console.WriteLine("Dashboard page is being displayed in PSC");
                    Console.WriteLine("---------------------------------------------------------------------------\n");
                    Assert.Ignore();
                    
                }  
                Thread.Sleep(4000);
                flag = bip.VerifyPatientAdded();
                bip.GoToDashBoard();
                if (flag)
                {
                    search.SearchPatient("duplicatepatients.csv", patientid);
                    int nop = search.FindNumberOfSearchPatients();
                    if (nop > 1)
                    {
                        Console.WriteLine("-------------------Test Completed for " + patientid + "     ---------------------");
                        Console.WriteLine("Test FAILED. Actual Result: PSC is allowing to add duplicate Patients using Add Patient option");
                        Console.WriteLine("\n---------------------------------------------------------------------------\n");
                        Assert.Fail("-----------Test Failed -------------------");                        
                    }
                    flag = false;
                 }
                if(!flag)
                {
                    Console.WriteLine("-------------------Test Completed for " + patientid + "     ---------------------\n");
                    Console.WriteLine("Test PASSED! \n Actual Result: PSC is not allowing to add duplicate Patients");
                    Console.WriteLine("\n---------------------------------------------------------------------------\n");
                    Assert.Pass("-----------Test Passed -------------------");
                }
          }

        [Test, TestCaseSource("patientids")]
        public void PSCNotAllowingToAddDuplicatePatientUsingEdit(int patientid)
        {
                count++;
                Console.WriteLine("\n----------------------Testing Patient ID " + patientid + "-------------------------------------");
                Console.WriteLine("TEST-----> Verify if PSC allow to add duplicate patient using edit option");
                Console.WriteLine("Step1- Searching for the already added patient ");
                search.SearchPatient("duplicatepatients.csv", patientid);
                Thread.Sleep(5000);
                if (search.IsSearchEmpty())
                {
                    Console.WriteLine("Patient Found in PSC!!");
                    tabs.Dashboard();
                    flag = true;
                    Console.WriteLine("---------------------------------------------------------------------------\n");
                    Assert.Ignore("Ignoring this patient as this patient doesn't exist in PSC");
                }
                Console.WriteLine("Step2: Patient already added in PSC, So opening the patient information in PSC");
                search.SelectFirstSearchRecord();
                Thread.Sleep(2000); 
                Console.WriteLine("Additional Step: Going to BasicInfo page, if any other page opens in PSC");
                bip.GoBackToBasicInfoPage();
                Thread.Sleep(2000);
                Console.WriteLine("Step3: Patient Information open in PSC");
                Console.WriteLine("Step4: Click on Edit to edit user information");
                standard.Edit();
                Console.WriteLine("Step5: Edit option clicked and patient information can be modified");
                if (count == 0)
                {
                    Console.WriteLine("Step 6: Adding already existing patient --" + patientids[count + 1] + "-- from data file");
                    bip.ProvideFirstName("duplicatepatients.csv", patientids[count + 1]);
                    bip.ProvideLastName("duplicatepatients.csv", patientids[count + 1]);
                    bip.ProvideDOB("duplicatepatients.csv", patientids[count + 1]);
                    bip.ProvideBasicInformation("duplicatepatients.csv", patientids[count + 1]);
                    Thread.Sleep(2000);
                    if (!standard.Save())
                    {
                        Console.WriteLine("Result:  Not able to add new patient as patient information is not correct in one or more basic info fields");
                        Console.WriteLine(" INFO:  Please check the screenshot for more information");
                        Thread.Sleep(2000);
                        bip.GoToDashBoard();
                        Console.WriteLine("---------------------------------------------------------------------------\n");
                        Assert.Ignore();
                        
                    }  
                }
                else
                {
                    bip.ProvideFirstName("duplicatepatients.csv", patientids[count - 1]);
                    bip.ProvideLastName("duplicatepatients.csv", patientids[count - 1]);
                    bip.ProvideDOB("duplicatepatients.csv", patientids[count - 1]);
                    bip.ProvideBasicInformation("duplicatepatients.csv", patientids[count - 1]);
                    Console.WriteLine("Step 6: Adding already existing patient --" + patientids[count - 1] + " -- from data file");
                    Thread.Sleep(2000);
                    if (!standard.Save())
                    {
                        Console.WriteLine("Result:  Not able to add new patient as patient information is not correct in one or more basic info fields");
                        Console.WriteLine(" INFO:  Please check the screenshot for more information");
                        Thread.Sleep(2000);
                        bip.GoToDashBoard();
                        Assert.Ignore("TEST IGNORED:  Not able to run test for this patient because full information not provided");
                        Console.WriteLine("---------------------------------------------------------------------------\n");
                    }  
                }
                Thread.Sleep(4000);
                flag = bip.VerifyPatientAdded();
                bip.GoToDashBoard();
                if (flag)
                {
                    search.SearchPatient("duplicatepatients.csv", patientid);
                    int nop = search.FindNumberOfSearchPatients();
                    if (nop > 1)
                    {
                        Console.WriteLine("-------------------Test Completed for " + patientid + "     ---------------------");
                        Console.WriteLine("Test FAILED. Actual Result: PSC is allowing to add duplicate Patients");
                        Console.WriteLine("---------------------------------------------------------------------------\n");
                        Assert.Fail("-----------Test Failed -------------------");
                    }
                    flag = false;
                }
                if(!flag)
                {
                    Console.WriteLine("-------------------Test Completed for " + patientid + " ----------------------------");
                    Console.WriteLine("\nTest PASSED! \nActual Result: PSC is not allowing to add duplicate Patients\n");
                    Console.WriteLine("-------------------------------------------------------------------------------------------\n");
                    Assert.Pass();
                }
          }         
    }    
}


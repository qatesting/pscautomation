using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSCTest.tests
{
    class TestsStructure
    {

        /*SampleTest test = new SampleTest();
            
        Login.loginPSC(currentWindow);
        Thread.Sleep(5000);
        Screenshot screen = new Screenshot();
        screen.GetScreenshot("temp.png");
        search.SearchPatient(1);
        Thread.Sleep(5000);
        bool flag = search.IsSearchEmpty();
        if (flag == true)
        {
            Console.WriteLine("Not able to search the patient, So adding the patient");
            search.AddNewPatient();
            test.ProvideNewPatientInformation();
        }
        else if (flag == false)
        {
            Console.WriteLine("Patient Found");
            search.SelectFirstSearchRecord();
        }
        //test.InputAdditionInfo();
        //test.AddGuardianInformation();
        //test.PerformOperations();
        //test.AddInsuranceInfo();
        //test.AddNewPatient(); */


        /*       public void InputAdditionInfo()
                {
                    AdditionalInfoPage aip = new AdditionalInfoPage(currentWindow);
                    standard.Next();
                    Thread.Sleep(5000);
                    aip.ProvideMailingAddress(1);
                    Thread.Sleep(2000);
                    // aip.SameAsMailingAddress("No");
                    // aip.ProvideBillingAddress(1);
            
                }

                public void AddInsuranceInfo()
                {
                    for (int i = 0; i < 10; i++)
                        standard.Back();

                    Thread.Sleep(5000);
                    AdditionalInfoPage aip = new AdditionalInfoPage(currentWindow);            
                    Thread.Sleep(2000);
                    aip.AddInsurance(1);
                }

                public void AddGuardianInformation()
                {
                    //standard.Next();
                    standard.Next();
                    Thread.Sleep(5000);
                    AdditionalInfoPage aip = new AdditionalInfoPage(currentWindow);
                    //aip.AddGuardian(1);
                    aip.AddEmergencyContact(1);
                    Thread.Sleep(1000);
                    standard.Delete();
                    Thread.Sleep(2000);
                    standard.Ok();
                    //standard.Delete();
                }

                public void PerformOperations()
                {            
                    //StandardOperations standard = new StandardOperations(currentWindow);
                    Thread.Sleep(5000);
                    tabs.Dashboard();
                    Thread.Sleep(5000);
                    standard.Cancel();
                    Thread.Sleep(5000);
                    tabs.Dashboard();
                    Thread.Sleep(5000);
                    standard.Ok();           
                    Console.ReadLine();
                }*/
    }
}

using System;
using TestStack.White;
using Window = TestStack.White.UIItems.WindowItems.Window;
using TestStack.White.UIItems.Finders;
using PSCTest.core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using Thread = System.Threading.Thread;
using System.Collections.Generic;
using TestStack.White.InputDevices;

namespace PSCTest.utilities
{
    class BasicInfoPage
    {        
        Window basicinfowindow;
        ReadJson rj;
        StandardOperations standard;
        Dictionary<string, string> basicinfo;
        GetPatientData gpd;
 
        public BasicInfoPage(Window window)
        {
            this.basicinfowindow = window;            
            standard = new StandardOperations(window);
            rj = new ReadJson("addpatientpage.json");
            basicinfo = new Dictionary<string, string>();
            gpd = new GetPatientData();
        }

        //Get Basic Info Address from the file
        public void GetBasicInformation(int key)
        {
            basicinfo = gpd.GetPatient("patientadditionalinfo.csv", key);            
        }

        //Input the value of the patient in PSC
        public bool ProvideBasicInformation(int key)
        {
            bool flag = false;
            GetBasicInformation(key);
            try
            {
                Thread.Sleep(2000);
                string gender = basicinfo["Gender"];
                gender = gender.ToUpper();
                if (gender.Equals("M"))
                    Input.ClickOnSpecificItemByName(basicinfowindow, rj.GetElementValue("Male"));
                else if (gender.Equals("F"))
                    Input.ClickOnSpecificItemByName(basicinfowindow, rj.GetElementValue("Female"));
                else{
                    Console.WriteLine("Not able to find the element");
                    flag = true;    }       
         
                Thread.Sleep(1000);
                if (flag == true)
                    ProvideZipCode(basicinfo["ZipCode"]);
                else
                    Input.TabAndInputText(basicinfo["ZipCode"]);
                Thread.Sleep(1000);
                Input.TabAndInputText(basicinfo["MobilePhone"]);
                Thread.Sleep(1000);
                Input.TabAndInputText(basicinfo["HomePhone"]);
                Thread.Sleep(1000);
                Input.TabAndInputText(basicinfo["Email"]);
                Thread.Sleep(1000);
                ProvidePreferedCommunication(basicinfo["PreferredMethodOfContact"]);
                Thread.Sleep(2000);
                ProvidePreferedLangauge(basicinfo["PreferredCommunicationLangauge"]);

                return true;
            }
            catch(Exception)
            {
                Console.WriteLine("Not able to provide basic information");
                return false;
            }
        }

        //Provide Zip Code
        public bool ProvideZipCode(string values)
        {
            try
            {
                Input.ClickOnSpecificItemByAutomationID(basicinfowindow, rj.GetElementValue("Idhasverified"));
                Thread.Sleep(1000);
                Input.ClickOnSpecificItemByAutomationID(basicinfowindow, rj.GetElementValue("Idhasverified"));
                Thread.Sleep(1000);
                for (int i = 0; i < 10; i++)
                    Input.ReverseSwitchTextBox();
                Input.ClearAll();
                Input.TypeKeyword(values);
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine("Not able to find the zipcode item");
                return false;
            }
        }

        //Provide Communication langauge
        public bool ProvidePreferedCommunication(string value)
        {
            value = value.ToLower();
            try
            {
                if (value.Contains("mobile"))
                    Input.ClickOnSpecificItemByName(basicinfowindow, "PreferMobilePhone");
                else if (value.Contains("home"))
                    Input.ClickOnSpecificItemByName(basicinfowindow, "PreferHomePhone");
                else if (value.Contains("email"))
                    Input.ClickOnSpecificItemByName(basicinfowindow, "PreferEmail");
                else if (value.Contains("sms"))
                    Input.ClickOnSpecificItemByName(basicinfowindow, "PreferSMS");
                else
                    Console.WriteLine("No value find for the PreferredMethod");
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine("Not able to find the element");
                return false;
            }
        }
        public bool ProvidePreferedLangauge(string value)
        {
            value = value.ToLower();
            Input.ClickOnSpecificItemByName(basicinfowindow, rj.GetElementValue("Idhasverified"));
            Thread.Sleep(3000);
            Input.ClickOnSpecificItemByName(basicinfowindow, rj.GetElementValue("Idhasverified"));
            Thread.Sleep(2000);
            try
            {
                Input.ReverseTabAndInputText(value);
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine("Not able to find the Prefered Langauge item");
                return false;
            }
        }
    }
}

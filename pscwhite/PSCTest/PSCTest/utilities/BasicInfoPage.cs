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
        Tabs tabs;
 
        public BasicInfoPage(Window window)
        {
            this.basicinfowindow = window;            
            standard = new StandardOperations(window);
            rj = new ReadJson("addpatientpage.json");
            basicinfo = new Dictionary<string, string>();
            tabs = new Tabs(window);
            gpd = new GetPatientData();            
        }

        //Get Basic Info Address from the file
        public void GetBasicInformation(int key)
        {
            GetBasicInformation("patientadditionalinfo.csv",key);        
        }

        //Overide method of GetBasicInformation
        public void GetBasicInformation(string filename, int key)
        {
            basicinfo = gpd.GetPatient(filename, key);    
        }

        //Input the value of the patient in PSC
        public bool ProvideBasicInformation(string filename, int key)
        {
            bool flag = false;
            GetBasicInformation(filename,key);
            Console.WriteLine("\nFollowing information will be add in PSC for patient");
            Console.WriteLine("----------------------------------------------------------------\n");            
            foreach (KeyValuePair<string, string> kvp in basicinfo)
                Console.WriteLine(kvp.Key+" ->  "+kvp.Value);
            Console.WriteLine("\n----------------------------------------------------------------\n");
            try
            {
                Thread.Sleep(1000);
                ProvideMiddleName(filename, key);
                Thread.Sleep(1000);
                ProvideGender(filename, key);          
                Thread.Sleep(1000);
                ProvideZipCode(filename, key);
                Thread.Sleep(1000);
                ProvideMobilePhone(filename, key);
                Thread.Sleep(1000);
                ProvideHomePhone(filename, key);
                Thread.Sleep(1000);
                ProvideEmail(filename, key);
                Thread.Sleep(1000);
                ProvidePreferedCommunication(filename, key);
                Thread.Sleep(2000);
                ProvidePreferedLangauge(filename, key);
                Thread.Sleep(2000);
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>  Not able to provide basic information <<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        //Provide First Name 
        public bool ProvideFirstName(string filename, int key)
        {
            GetBasicInformation(filename, key);
            try
            {
                Input.ClickOnSpecificItemByAutomationID(basicinfowindow, rj.GetElementValue("PatientDOB"));
                Input.ReverseSwitchTextBox();
                Input.ReverseSwitchTextBox();
                Input.ReverseTabAndInputText(basicinfo["FirstName"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>> Not able to find input any value on First Name field <<<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        //Provide Middle Name 
        public bool ProvideMiddleName(string filename, int key)
        {
            GetBasicInformation(filename, key);
            try
            {
                Input.ClickOnSpecificItemByAutomationID(basicinfowindow, rj.GetElementValue("PatientDOB"));
                Input.ReverseSwitchTextBox();
                Input.ReverseTabAndInputText(basicinfo["MiddleName"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>     Not able to find input any value on Middle Name field  <<<<<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        //Provide Last Name 
        public bool ProvideLastName(string filename, int key)
        {
            GetBasicInformation(filename, key);
            try
            {
                Input.ClickOnSpecificItemByAutomationID(basicinfowindow, rj.GetElementValue("PatientDOB"));
                Input.ReverseTabAndInputText(basicinfo["LastName"]);
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>  Not able to find input any value on Last Name field  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        //Provide Date of Birth
        public bool ProvideDOB(string filename, int key)
        {
            GetBasicInformation(filename, key);
            try
            {
                Thread.Sleep(1000);
                Input.ClickOnSpecificItemByAutomationID(basicinfowindow, rj.GetElementValue("PatientDOB"));
                Input.ClearAll();
                Input.Type(basicinfowindow,rj.GetElementValue("PatientDOB"),basicinfo["DOB"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>> Not able to find the Mobile Phone item <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        //Provide Gender Information
        public bool ProvideGender(string filename, int key)
        {
            bool flag = false;
            GetBasicInformation(filename, key);
            try
            {
                Thread.Sleep(2000);
                string gender = basicinfo["Gender"];
                gender = gender.ToUpper();
                if (gender.Equals("M"))
                    Input.ClickOnSpecificItemByName(basicinfowindow, rj.GetElementValue("Male"));
                else if (gender.Equals("F"))
                    Input.ClickOnSpecificItemByName(basicinfowindow, rj.GetElementValue("Female"));
                else
                {
                    Console.WriteLine(">>>>>>>>>>>>>Not able to find the element of Gender");
                    flag = true;
                }
                return flag;
            }

            catch(Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>> Not able to provide Gender <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        //Provide Mobile Phone
        public bool ProvideMobilePhone(string filename, int key)
        {
            GetBasicInformation(filename, key);
            try
            {
                AccessZipCode();
                Thread.Sleep(1000);
                Input.TabAndInputText(basicinfo["MobilePhone"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>> Not able to find the Mobile Phone item <<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        //Provide Home Phone
        public bool ProvideHomePhone(string filename, int key)
        {
            GetBasicInformation(filename, key);
            try
            {
                AccessZipCode();
                Thread.Sleep(1000);
                Input.SwitchTextBox();
               // Console.WriteLine("Value of HOME Phone :" + basicinfo["HomePhone"]);
                Input.TabAndInputText(basicinfo["HomePhone"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>> Not able to find the Mobile Phone item <<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        //Provide Email id
        public bool ProvideEmail(string filename, int key)
        {
            GetBasicInformation(filename, key);
            try
            {
                AccessZipCode();
                Thread.Sleep(1000);
                Input.SwitchTextBox();
                Input.SwitchTextBox();
              //  Console.WriteLine("Value of EMAIL :" + basicinfo["Email"]);
                Input.TabAndInputText(basicinfo["Email"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>> Not able to find the Mobile Phone item <<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        //Provide Zip Code
        public bool ProvideZipCode(string filename, int key)
        {
            GetBasicInformation(filename, key);
            try
            {
                AccessZipCode();
                Input.ClearAll();
               // Console.WriteLine("Value of ZIP CODE :" + basicinfo["ZipCode"]);
                Input.TypeKeyword(basicinfo["ZipCode"]);
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>> Not able to find the zipcode item <<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        //Verify if save is enable or not
        public bool VerifyBasicInfoField()
        {
            bool result = standard.Save();
            return result;   
        }

        //Provide Communication langauge
        public bool ProvidePreferedCommunication(string filename, int key)
        {
            GetBasicInformation(filename, key);
            String value = basicinfo["PreferredMethodOfContact"].ToLower();
            //Console.WriteLine("Value of PreferredMethodofContact :" +value);
            try
            {
                if (value.Contains("mobile"))
                    Input.ClickOnSpecificItemByName(basicinfowindow, rj.GetElementValue("PreferMobilePhone"));
                else if (value.Contains("home"))
                    Input.ClickOnSpecificItemByName(basicinfowindow, rj.GetElementValue("PreferHomePhone"));
                else if (value.Contains("email"))
                    Input.ClickOnSpecificItemByName(basicinfowindow, rj.GetElementValue("PreferEmail"));
                else if (value.Contains("sms"))
                    Input.ClickOnSpecificItemByName(basicinfowindow, rj.GetElementValue("PreferSMS"));
                else
                    Console.WriteLine("No value find for the PreferredMethod");
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>> Not able to find the element for PreferredMethod of Contact <<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        //Provide Preferred Langauge
        public bool ProvidePreferedLangauge(string filename, int key)
        {
            GetBasicInformation(filename, key);
            String value = basicinfo["PreferredCommunicationLangauge"].ToLower();
            Input.ClickOnSpecificItemByName(basicinfowindow, rj.GetElementValue("Idhasverified"));
            Thread.Sleep(1000);
            Input.ClickOnSpecificItemByName(basicinfowindow, rj.GetElementValue("Idhasverified"));
            Thread.Sleep(1000);
            try
            {
                for (int i = 0; i < 2; i++)
                    Input.ReverseSwitchTextBox();
                Input.TypeKeyword(basicinfo["PreferredCommunicationLangauge"]);
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>> Not able to find the Prefered Langauge item  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        public bool AccessZipCode()
        {
            try
            {
                Thread.Sleep(1000);
                Input.ClickOnSpecificItemByAutomationID(basicinfowindow, rj.GetElementValue("ZipCode"));
                Thread.Sleep(1000);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>> Not able to find the zipcode item <<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        //Verify if patient already exist in PSC
        public bool IsAnotherPatientExist()
        {
            bool result = Input.ClickOnSpecificItemByName(basicinfowindow, rj.GetElementValue("AnotherPatientExist"));
            return result;
        }

        //Go to BasicInfo page
        public bool GoBackToBasicInfoPage()
        {
            //bool result = standard.Back();
            while (standard.Back())
                   continue;              
            return true;
        }

        public bool VerifyPatientAdded()
        {
            try
            {
                Thread.Sleep(5000);
                if (!IsAnotherPatientExist())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>> Exception raised while adding the patient <<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }

        public void GoToDashBoard()
        {
            try
            {
                Thread.Sleep(4000);
                tabs.Dashboard();
                Thread.Sleep(5000);
                standard.Ok();
                Thread.Sleep(5000);
            }
            catch (Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>> Exception raised on clicking the dashboard button <<<<<<<<<<<<<<<<<<<<<");
            }
        }

        public bool AddPatient(string filename, int patientid)
        {
            try
            {
                SearchPage search = new SearchPage(basicinfowindow);
                search.AddNewPatient();
                Thread.Sleep(4000);
                ProvideBasicInformation(filename, patientid);
                Thread.Sleep(2000);
                return true;             
            }
            catch (Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>> Exception raised while adding the patient  <<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }
    }
}

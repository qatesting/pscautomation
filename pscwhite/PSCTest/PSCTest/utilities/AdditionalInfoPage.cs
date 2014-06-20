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
    class AdditionalInfoPage
    {
        Window additionalinfowindow;
        ReadJson rj;
        StandardOperations standard;
        Dictionary<string, string> additionalinfo;
        GetPatientData gpd;
        bool checkvalue = false;

        public AdditionalInfoPage(Window window)
        {
            this.additionalinfowindow = window;            
            standard = new StandardOperations(window);
            rj = new ReadJson("additionalinfopage.json");
            additionalinfo = new Dictionary<string, string>();
            gpd = new GetPatientData();
        }

         //Get Mailling address from the file
        public void GetMailingAddress(string filename, int key)
        {
            additionalinfo = gpd.GetPatient(filename, key);            
        }

        //Get Guardian information from the file
        public void GetGuardianInformation(int key)
        {
            additionalinfo = gpd.GetPatient("guardianinfo.csv", key);
        }

        //Get Emergency Contact information from the file
        public void GetEmergencyContactInformation(int key)
        {
            additionalinfo = gpd.GetPatient("emergencycontactinfo.csv", key);
        }

        //Get Insurance Information from the file
        public void GetInsuranceInformation(int key)
        {
            additionalinfo = gpd.GetPatient("insuranceinfo.csv", key);
        }

        //Mailing Address information
        public bool ProvideMailingAddress(string filename, int key)
        {
            //Click on Same as Mailing Address to get the item
            ClickSameAsMailingAddress();
            //Give all the information about mailing information
            GetMailingAddress(filename, key);
            try
            {                  
                Input.ReverseTabAndInputText(additionalinfo["Mailing-State"]);
                Input.ReverseTabAndInputText(additionalinfo["Mailing-City"]);
                Input.ReverseTabAndInputText(additionalinfo["Mailing-ZipCode"]);
                Input.ReverseTabAndInputText(additionalinfo["Mailing-Street2"]);
                Input.ReverseTabAndInputText(additionalinfo["Mailing-Street1"]);              
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to complete mailing address information");
                return false;
            }
        }

        //Providing Street Code
        public bool ProvideMailingStreet(string filename, int key)
        {
            //Click on Same as Mailing Address to get the item
            ClickSameAsMailingAddress();
            //Give all the information about mailing information
            GetMailingAddress(filename, key);
            try
            {
                Input.ReverseSwitchTextBox();
                Input.ReverseSwitchTextBox();
                Input.ReverseSwitchTextBox();
                Input.ReverseTabAndInputText(additionalinfo["Mailing-Street2"]);
                Input.ReverseTabAndInputText(additionalinfo["Mailing-Street1"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to provide Street1 and Street2 information");
                return false;
            }
        }

        //Providing Street address
        public bool ProvideMailingZipCode(string filename, int key)
        {
            //Click on Same as Mailing Address to get the item
            ClickSameAsMailingAddress();
            //Give all the information about mailing information
            GetMailingAddress(filename, key);
            try
            {
                Input.ReverseSwitchTextBox();
                Input.ReverseSwitchTextBox();
                Input.ReverseTabAndInputText(additionalinfo["Mailing-ZipCode"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to provide ZipCode of this address");
                return false;
            }
        }

        //Providing City in Mailing Address
        public bool ProvideMailingCity(string filename, int key)
        {
            //Click on Same as Mailing Address to get the item
            ClickSameAsMailingAddress();
            //Give all the information about mailing information
            GetMailingAddress(filename, key);
            try
            {
                Input.ReverseSwitchTextBox();
                Input.ReverseTabAndInputText(additionalinfo["Mailing-City"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to complete City name");
                return false;
            }
        }

        //Provide State of the patient
        public bool ProvideMailingState(string filename, int key)
        {
            //Click on Same as Mailing Address to get the item
            ClickSameAsMailingAddress();
            //Give all the information about mailing information
            GetMailingAddress(filename, key);
            try
            {
                Input.ReverseTabAndInputText(additionalinfo["Mailing-State"]);
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine("Not able to provide State name for the patient");
                return false;
            }
        }

        //Click on Same As Mailing Address
        public bool SameAsMailingAddress()
        {
             try
                {
                    Input.Click(additionalinfowindow, rj.GetElementValue("SameAsMailingAddress"));
                    checkvalue = true;
                    return checkvalue;
                }
                catch(Exception)
                {
                    Console.WriteLine("Not able to click Same As Mailing Address");
                    checkvalue = false;
                    return checkvalue;
                }   
        } 
     
        //Mailing Address information
        public bool ProvideBillingAddress(string filename, int key)
        {
            ClickSameAsMailingAddress();
            //Give all the information about mailing information
            GetMailingAddress(filename, key);
            try
            {
                Input.SwitchTextBox(1);
                Input.TabAndInputText(additionalinfo["Billing-Street1"]);
                Input.TabAndInputText(additionalinfo["Billing-Street2"]);
                Input.TabAndInputText(additionalinfo["Billing-ZipCode"]);
                Input.TabAndInputText(additionalinfo["Billing-City"]);
                Input.TabAndInputText(additionalinfo["Billing-State"]);
                return true;
             }
            catch(Exception)
            {
                Console.WriteLine("Not able to complete billing address information");
                return false;
            }
        }

        //Providing Street Code
        public bool ProvideBillingStreet(string filename, int key)
        {
            //Click on Same as Mailing Address to get the item
            ClickSameAsMailingAddress();
            //Give all the information about mailing information
            GetMailingAddress(filename, key);
            try
            {
                Input.SwitchTextBox(1);
                Input.TabAndInputText(additionalinfo["Billing-Street1"]);
                Input.TabAndInputText(additionalinfo["Billing-Street2"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to provide Street1 and Street2 information");
                return false;
            }
        }

        //Providing Street address
        public bool ProvideBillingZipCode(string filename, int key)
        {
            //Click on Same as Mailing Address to get the item
            ClickSameAsMailingAddress();
            //Give all the information about mailing information
            GetMailingAddress(filename, key);
            try
            {
                Input.SwitchTextBox(3);
                Input.TabAndInputText(additionalinfo["Billing-ZipCode"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to provide ZipCode of this address");
                return false;
            }
        }

        //Providing City in Mailing Address
        public bool ProvideBillingCity(string filename, int key)
        {
            //Click on Same as Mailing Address to get the item
            ClickSameAsMailingAddress();
            //Give all the information about mailing information
            GetMailingAddress(filename, key);
            try
            {
                Input.SwitchTextBox(4);
                Input.TabAndInputText(additionalinfo["Billing-City"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to complete City name in billing address");
                return false;
            }
        }

        //Provide State of the patient
        public bool ProvideBillingState(string filename, int key)
        {
            //Click on Same as Mailing Address to get the item
            ClickSameAsMailingAddress();
            //Give all the information about mailing information
            GetMailingAddress(filename, key);
            try
            {
                Input.SwitchTextBox(5);
                Input.TabAndInputText(additionalinfo["Billing-State"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to provide State name for the patient in Billing Address");
                return false;
            }
        }

        public void ClickSameAsMailingAddress()
        {
            //Click on Additional Info button
            Input.Click(additionalinfowindow, rj.GetElementValue("SameAsMailingAddress"));
            Thread.Sleep(1000);
            Input.Click(additionalinfowindow, rj.GetElementValue("SameAsMailingAddress"));
            Thread.Sleep(2000);
        }

        //Click on Guardian button
        public void SelectGuardian()
        {
            Input.ClickOnSpecificItemByName(additionalinfowindow, rj.GetElementValue("AddGuardian"));
            Thread.Sleep(1000);
        }

        //Provide information on Guardian 
        public bool AddGuardian(int key)
        {
            try
            {
                SelectGuardian();
                GetGuardianInformation(key);
                Thread.Sleep(1000);
                standard.Delete();
                Thread.Sleep(2000);
                standard.Cancel();
                Thread.Sleep(1000);
                Input.ReverseTabAndInputText(additionalinfo["DOB"]);
                Input.ReverseTabAndInputText(additionalinfo["Relationship"]);
                Input.ReverseTabAndInputText(additionalinfo["Phone"]);
                Input.ReverseTabAndInputText(additionalinfo["LastName"]);
                Input.ReverseTabAndInputText(additionalinfo["FirstName"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to add the guardian");
                return false;
            }
        }

        //Click on Add Emergency Contacts
        //Click on Guardian button
        public void SelectAddEmergencyContact()
        {
            Input.ClickOnSpecificItemByName(additionalinfowindow, rj.GetElementValue("AddEmergencyContact"));
            Thread.Sleep(1000);
        }

        //Provide information on Guardian 
        public bool AddEmergencyContact(int key)
        {
            try
            {
                SelectAddEmergencyContact();
                GetEmergencyContactInformation(key);
                Thread.Sleep(1000);
                standard.Delete();
                Thread.Sleep(2000);
                standard.Cancel();
                Thread.Sleep(1000);
                Input.ReverseTabAndInputText(additionalinfo["Relationship"]);
                Input.ReverseTabAndInputText(additionalinfo["Phone"]);
                Input.ReverseTabAndInputText(additionalinfo["LastName"]);
                Input.ReverseTabAndInputText(additionalinfo["FirstName"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to add the guardian");
                return false;
            }
        }

        //Click on Guardian button
        public void SelectInsurance()
        {
            Input.ClickOnSpecificItemByName(additionalinfowindow, rj.GetElementValue("AddInsurance"));
            Thread.Sleep(1000);
        }

        //Provide information of Insurance
        public bool AddInsurance(int key)
        {
            try
            {
                SelectInsurance();
                GetInsuranceInformation(key);
                Thread.Sleep(1000);
                Input.ClickOnSpecificItemByName(additionalinfowindow, rj.GetElementValue("ScanInsuranceBack"));
                Thread.Sleep(1000);
                for (int i = 0; i < 3; i++ )
                    Input.SwitchTextBox();
                Input.ClearAll();
                Input.TypeKeyword(additionalinfo["FirstName"]);
                Input.TabAndInputText(additionalinfo["LastName"]);
                GetPlanType();                
                Input.ReverseTabAndInputText(additionalinfo["GroupNumber"]);
                Thread.Sleep(1000);
                Input.ReverseTabAndInputText(additionalinfo["PolicyNumber"]);
                Thread.Sleep(1000);
                Input.ReverseTabAndInputText(additionalinfo["InsuranceProvider"]);               
                Thread.Sleep(2000);
                standard.Save();
                Thread.Sleep(2000);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to add the guardian");
                return false;
            }
        }

        //Get Plan Type
        public bool GetPlanType()
        {
            try
            {
                Input.ClickOnSpecificItemByClass(additionalinfowindow, rj.GetElementValue("PlanType"));
                Thread.Sleep(1000);
                string plantype = additionalinfo["PlanType"];
                plantype = plantype.ToUpper();
                Thread.Sleep(1000);
                if (plantype.Equals("EPO"))
                    Input.Down();
                if (plantype.Equals("HMO"))
                {
                    Input.Down();
                    Input.Down();
                }
                if (plantype.Equals("PPO"))
                {
                    Input.Down();
                    Input.Down();
                    Input.Down();
                }
                if (plantype.Equals("OTHER"))
                {
                    Input.Down();
                    Input.Down();
                    Input.Down();
                    Input.Down();
                    Thread.Sleep(1000);
                    Input.TypeKeyword(additionalinfo["OtherPlanType"]);
                    Thread.Sleep(2000);
                }
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine("Not able to get the plan type");
                return true;
            }            
        }

        //Less then 18 years of Age
        public bool IsPatientAgeIsLessThen18Years()
        {
            bool flag = Input.ClickOnSpecificItemByAutomationID(additionalinfowindow, rj.GetElementValue("LessThen18YearsAge"));
            return flag;
        }

        //Verify if Next button is enable or not
        public bool VerifyAdditionalInfoField()
        {
            bool result = standard.Next();
            return result;
        }

        //Verifiying if Checkbox is checked
        public bool IsSameAsMailingAddressChecked(string filename, int key)
        {
            try
            {
                ProvideMailingAddress(filename,key);
                ClickSameAsMailingAddress();
                Input.SwitchTextBox(2);
                Input.ClearAll();
                if (VerifyAdditionalInfoField())
                {
                    standard.Back();
                    return true;
                }
                else
                    return false;
            }
            catch(Exception)
            {
                Console.WriteLine("Checkbox seems to be checked");
                return true;
            }                   
        }
        
        //Go to Additional Info page
        public bool GoToAdditionalInfoPage()
        {
            try
            {
                while (standard.Back())
                    continue;
                standard.Next();
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>> Reach to additionalInfo page <<<<<<<<<<<<<<<<<<<<<<<");
                return false;
            }
        }
    }
}

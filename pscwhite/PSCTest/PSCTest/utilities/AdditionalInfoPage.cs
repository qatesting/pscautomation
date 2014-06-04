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
        public void GetMailingAddress(int key)
        {
            additionalinfo = gpd.GetPatient("mailingaddressinfo.csv", key);            
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
        public bool ProvideMailingAddress(int key)
        {
            //Click on Same as Mailing Address to get the item
            ClickSameAsMailingAddress();
            //Give all the information about mailing information
            GetMailingAddress(key);
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

        //Click on Same As Mailing Address
        public bool SameAsMailingAddress(string value)
        {
            value = value.ToLower();
            if(value.Equals("yes"))
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
            return checkvalue;
        }   

        //Mailing Address information
        public bool ProvideBillingAddress(int key)
        {
            if (checkvalue == true)
                return false;
            ClickSameAsMailingAddress();
            //Give all the information about mailing information
            GetMailingAddress(key);
            try
            {
                Input.ReverseTabAndInputText(additionalinfo["Billing-Street1"]);
                Input.ReverseTabAndInputText(additionalinfo["Billing-Street2"]);
                Input.ReverseTabAndInputText(additionalinfo["Billing-ZipCode"]);
                Input.ReverseTabAndInputText(additionalinfo["Billing-City"]);
                Input.ReverseTabAndInputText(additionalinfo["Billing-State"]);
                return true;
             }
            catch(Exception)
            {
                Console.WriteLine("Not able to complete billing address information");
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
      
    }
}

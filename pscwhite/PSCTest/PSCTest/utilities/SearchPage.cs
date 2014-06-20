/*          This Class is to handle all the features of Search page.
 *          This class contains all the methods which handle all the features of Search page */

using System;
using TestStack.White;
using Window = TestStack.White.UIItems.WindowItems.Window;
using TestStack.White.UIItems.Finders;
using PSCTest.core;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using Thread = System.Threading.Thread;
using System.Collections.Generic;
using TestStack.White.UIItems.ListBoxItems;

namespace PSCTest.utilities
{
    class SearchPage
    {
        Window searchwindow;
        ReadJson rj;
        StandardOperations standard;
        Dictionary<string, string> searchpatients;
        GetPatientData gpd = new GetPatientData();

        public SearchPage(Window window)
        {
            this.searchwindow = window;
            rj = new ReadJson("searchpage.json");
            standard = new StandardOperations(window);
            searchpatients = new Dictionary<string, string>();
        }

        public void SearchPatientData(int key)
        {
            searchpatients = gpd.GetPatient("patientinformation.csv",key);
        }

        public void SearchPatient(int key)
        {
            Thread.Sleep(3000);
            searchpatients = gpd.GetPatient("patientinformation.csv", key);
            EnterLastName();
            Thread.Sleep(1000);
            EnterFirstName();
            Thread.Sleep(1000);
            EnterDOB();
            Thread.Sleep(2000);
            SelectSearch();
        }

        public void SearchPatient(string filename, int key)
        {
            Thread.Sleep(3000);
            searchpatients = gpd.GetPatient(filename, key);
            EnterLastName();
            Thread.Sleep(1000);
            EnterFirstName();
            Thread.Sleep(1000);
            EnterDOB();
            Thread.Sleep(2000);
            SelectSearch();
            Thread.Sleep(3000);
        }

        public bool EnterLastName()
        {
            try
            {
                Input.Type(searchwindow, rj.GetElementValue("LastName"), searchpatients["LastName"]);
                return true;
            }
            catch(Exception){
                Console.WriteLine("Not able to enter the value");
                return false;
            }
        }

        public bool EnterFirstName()
        {
            try
            {
                Input.Type(searchwindow, rj.GetElementValue("FirstName"), searchpatients["FirstName"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to enter the value");
                return false;
            }
        }

        public bool EnterDOB()
        {
            try
            {
                Input.Type(searchwindow, rj.GetElementValue("DOB"), searchpatients["DOB"]);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to enter value");
                return false;
            }
        }

        public bool SelectSearch()
        {
            try
            {
                Input.Click(searchwindow, rj.GetElementValue("Search"));
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to Select");
                return false;
            }
        }

        public bool SelectFirstSearchRecord()
        {
            try
            {
                System.Threading.Thread.Sleep(3000);
                TestStack.White.UIItems.ListBoxItems.ListItem listView = searchwindow.Get<TestStack.White.UIItems.ListBoxItems.ListItem>(SearchCriteria.ByText("Theranos.PSC.UI.PatientViewModel"));                   
                listView.Select();
                Thread.Sleep(3000);
                standard.Next();              
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to Find any record");
                return true;
            }
        }

        public bool SelectSearchRecord()
        {
            try
            {
                Thread.Sleep(3000);
                TestStack.White.UIItems.IUIItem[] item = searchwindow.GetMultiple(SearchCriteria.ByClassName("ListBox"));                
                Thread.Sleep(5000);        
                return true;
            }           
            catch(Exception)
            {
                Console.WriteLine("Not able to find this record"); 
                return false;
            }
        }

        //Add new patient
        public bool AddNewPatient()
        {
            try
            {
                Input.ClickOnSpecificItemByName(searchwindow, rj.GetElementValue("AddNewPatient"));
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine("Not able to click on Add New Patient");
                return false;
            }
        }

        //Verify how many record find out
        public bool IsSearchEmpty()
        {
            try
            {
                TestStack.White.UIItems.IUIItem[] item = searchwindow.GetMultiple(SearchCriteria.ByClassName("ListBox"));
                var p = searchwindow.Get<TestStack.White.UIItems.ListBoxItems.WPFListItem>(SearchCriteria.ByClassName("ListBoxItem"));
                if (p.Text.Equals("Theranos.PSC.UI.VisitViewModel"))
                    return true;
                return false;
            }
            catch(Exception)
            {
                Console.WriteLine("No Patient Found");
                return true;
            }
        }

        //Getting the values in Search
        public int FindNumberOfSearchPatients()
        {
            int count = 0;
            try
            {
                ListBox listBox = searchwindow.Get<ListBox>(SearchCriteria.ByClassName("ListBox"));
                count = listBox.Items.Count;
                return count;
            }
            catch (Exception)
            {
                Console.WriteLine("No Patient Found");
                return count;
            }
        }
    }
}

/* This Class is to perform different operations in PSC e.g. next, cancel ...etc.. */

using System;
using PSCTest.core;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Thread = System.Threading.Thread;

namespace PSCTest.core
{
    class StandardOperations
    {
        Window window;
        public StandardOperations(Window window)
        {
            this.window = window;
        }

        public bool Next()
        {
            Input.ClickOnSpecificItemByName(window, "Next");
            return true;
        }  

        public bool Back()
        {
            Input.ClickOnSpecificItemByName(window, "Back");
            return true;
        }

        public bool Save()
        {
            Input.ClickOnSpecificItemByName(window, "Save");
            return true;
        }

        public bool DeleteCard()
        {
            Input.ClickOnSpecificItemByName(window, "Delete Card");
            return true;
        }

        public bool Ok()
        {
            try
            {                
                Button ok = window.Get<Button>(SearchCriteria.ByText("OK"));
                ok.Click();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to find OK button");
                return false;                 
            }
        }

        public bool Delete()
        {
            Input.ClickOnSpecificItemByName(window, "Delete");
            return true;
        }

        public bool Cancel()
        {
            try
            {
                Button ok = window.Get<Button>(SearchCriteria.ByText("Cancel"));
                ok.Click();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to find CANCEL button");
                return false;
            }
        }
        
        //Click on Edit button
        public bool Edit()
        {
            try
            {
                Button edit = window.Get<Button>(SearchCriteria.ByText("Edit"));
                edit.Click();
                return true;
            }
            catch(Exception)
            {
                Console.WriteLine("Not able to click Edit button");
                return false;
            }
        }
    }
}

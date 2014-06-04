using System;
using PSCTest.core;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using Thread = System.Threading.Thread;

namespace PSCTest.utilities
{
    class Tabs
    {
        Window window;
        public Tabs(Window window)
        {
            this.window = window;
        }

        public bool Dashboard()
        {
            try
            {
                Input.Click(window, "goHomeButton");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to find DASHBOARD icon");
                return false;
            }
        }

        public bool BasicPatientInfo()
        {
            try
            {
                Input.Click(window, "Basic Patient Info");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to find basic patient info icon");
                return false;
            }
        }

        public bool AdditionalInfo()
        {
            try
            {
                Input.Click(window, "Additional Info");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to find Additional Info icon");
                return false;
            }
        }
 
        public bool SelectLabOrder()
        {
            try
            {
                Input.Click(window,"chkIsSelected");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to find Checkbox to select Lab Order");
                return false;
            }
        }        
    }
}

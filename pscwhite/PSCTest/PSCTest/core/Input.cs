using System;
using TestStack.White;
using pscWindow = TestStack.White.UIItems.WindowItems.Window;
using TestStack.White.UIItems.Finders;
using TextBox = TestStack.White.UIItems.TextBox;
using Radio = TestStack.White.UIItems.RadioButton;
using Button = TestStack.White.UIItems.Button;
using TestStack.White.InputDevices;
using System.Threading;

namespace PSCTest.core
{
    class Input
    {
        //This method Type the value which passed to this method
        public static bool Type(TestStack.White.UIItems.WindowItems.Window window, string elementid, string value)
        {
            try
            {
                TextBox textbox = window.Get<TextBox>(SearchCriteria.ByAutomationId(elementid));
                textbox.Text = value;
                return true;
            }
            catch (Exception)  {
                try
                {
                    TextBox textbox = window.Get<TextBox>(SearchCriteria.ByText(elementid));
                    textbox.Text = value;
                    return true;
                }
                catch (Exception)
                {
                    try
                    {
                        TextBox textbox = window.Get<TextBox>(SearchCriteria.ByClassName(elementid));
                        textbox.Text = value;
                        return true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Not able to find the element");
                        return false;
                    }
                }
             }
         }

        //This method select perticular button on the page
        public static bool Click(pscWindow window, string elementid)
        {
            try
            {
                Console.WriteLine("Trying to access the element using automation id");
                try
                {
                    Button button = window.Get<Button>(SearchCriteria.ByAutomationId(elementid));
                    button.Click();
                    return true;
                }
                catch (Exception)
                {
                    try
                    {
                        Console.WriteLine("Trying to access the element using Name of element");
                        Button button = window.Get<Button>(SearchCriteria.ByText(elementid));
                        button.Click();
                        return true;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            Console.WriteLine("Trying to access the element using ClassName id");
                            Button button = window.Get<Button>(SearchCriteria.ByClassName(elementid));
                            button.Click();
                            return true;
                        }
                        catch (Exception)
                        {   Console.WriteLine("Not able to find out the element id");
                            return false;     }
                    }
                }
            }
            catch (Exception)
            {   Console.WriteLine("Not able to click on button");
                return false;      }
        }
   
        //This method select when multiple Button Found for same AutomationID/Name/Class
        public static bool ClickOnSpecificItemByName(pscWindow window,string id)
        {
            try
            {
                TestStack.White.UIItems.IUIItem[] item= window.GetMultiple(SearchCriteria.ByText(id));
                int iter = 0;
                while (iter <= item.Length)
                {
                    try
                    {                        
                        item[iter].Click();
                        return true;
                    }
                    catch
                    {
                        iter++;
                        continue;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to find item");
                return false;
            }
        }

        //This method select any Item using AutomationID/Name/Class
        public static bool ClickOnSpecificItemByAutomationID(pscWindow window, string id)
        {
            try
            {
                TestStack.White.UIItems.IUIItem[] item = window.GetMultiple(SearchCriteria.ByAutomationId(id));
                int iter = 0;
                while (iter <= item.Length)
                {
                    try
                    {
                        item[iter].Click();
                        return true;
                    }
                    catch(Exception)
                    {
                        iter++;
                        continue;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to find the item on page");
                return false;
            }
        }

        //This method select when multiple Button Found for same AutomationID/Name/Class
        public static bool ClickOnSpecificItemByClass(pscWindow window, string id)
        {
            try
            {
                TestStack.White.UIItems.IUIItem[] item = window.GetMultiple(SearchCriteria.ByClassName(id));
                int iter = 0;
                while (iter <= item.Length)
                {
                    try
                    {
                        item[iter].Click();
                        return true;
                    }
                    catch
                    {
                        iter++;
                        continue;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("Not able to find item");
                return false;
            }
        }

        //This method Type the value which passed to this method
        public static bool SelectRadioButton(TestStack.White.UIItems.WindowItems.Window window, string elementid)
        {
            try
            {
                Radio radio = window.Get<Radio>(SearchCriteria.ByAutomationId(elementid));
                radio.Click();
                return true;
            }
            catch (Exception)
            {
                try
                {
                    Radio radio = window.Get<Radio>(SearchCriteria.ByText(elementid));
                    radio.Click();
                    return true;
                }
                catch (Exception)
                {
                    try
                    {
                        Radio radio = window.Get<Radio>(SearchCriteria.ByClassName(elementid));
                        radio.Click();
                        return true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Not able to find the element");
                        return false;
                    }
                }
            }
        }

        //Reverse SwitchTaxtBoxes using the key
        public static bool ReverseSwitchTextBox()
        {
            Keyboard.Instance.HoldKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.SHIFT);
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.TAB);
            Thread.Sleep(1000);
            Keyboard.Instance.LeaveKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.SHIFT);
            Thread.Sleep(2000);
            return true;
        }

        //SwitchTextBoxes using the tab key
        public static bool SwitchTextBox()
        {
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.TAB);
            Thread.Sleep(1000);
            return true;
        }
        
        //Clear TextBox data
        public static bool ClearAll()
        {
            Keyboard.Instance.HoldKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL);
            Thread.Sleep(1000);
            Keyboard.Instance.Enter("A");
            Thread.Sleep(1000);
            Keyboard.Instance.LeaveKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL);
            Thread.Sleep(2000);
            Keyboard.Instance.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.DELETE);
            return true;
        }

        //Type using keyword
        public static bool TypeKeyword(string value)
        {
            Thread.Sleep(1000);
            Keyboard.Instance.Enter(value);
            Thread.Sleep(1000);
            return true;
        }

        //Switching the tab with shift in reverse direction
        public static bool ReverseTabAndInputText(string inputvalue)
        {
            ReverseSwitchTextBox();
            Thread.Sleep(1000);
            ClearAll();
            Thread.Sleep(1000);
            TypeKeyword(inputvalue);
            Thread.Sleep(1000);
            return true;
        }

        //Switching the tab in down direction
        public static bool TabAndInputText(string inputvalue)
        {
            SwitchTextBox();
            Thread.Sleep(1000);
            ClearAll();
            Thread.Sleep(1000);
            TypeKeyword(inputvalue);
            Thread.Sleep(1000);
            return true;
        }

        //Select Enter using keyboard
        public static bool Enter()
        {
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.RETURN);
            Thread.Sleep(2000);
            return true;
        }

        //Select Down Key
        public static bool Down()
        {
            Thread.Sleep(1000);
            Keyboard.Instance.PressSpecialKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.DOWN);
            Thread.Sleep(2000);
            return true;
        }
    } 
}




using System;
using TestStack.White;
using Window = TestStack.White.UIItems.WindowItems.Window;
using TestStack.White.UIItems.Finders;

/*  This Class Login into the PSC with User Name and Password"
 * 
 */
namespace PSCTest.core
{
    class Login
    {
        public static void loginPSC(Window loginWindow)
        {
            Input.Type(loginWindow, "txtUsername", "labtech6@noreply.com");
            Input.Type(loginWindow, "txtPassword", "Theranos#123");

            Input.Click(loginWindow, "Login");
        }
     }
}

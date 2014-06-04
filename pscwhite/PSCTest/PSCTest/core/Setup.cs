/*  Purpose : This class launch the PSC application and return PSC applicaton window object
 * 
 *  Methods: This class has method called launchPSC which launch the psc window 
 * 
 */

using System;
using System.Diagnostics;
using TestStack.White.UIItems.Finders;
using WindowItems = TestStack.White.UIItems.WindowItems;
using TestStack.White.Factory;
using Application =  TestStack.White.Application;
using pscWindow = TestStack.White.UIItems.WindowItems.Window;
using Thread = System.Threading.Thread;

namespace PSCTest.core
{
    class Setup
    {
        public static Application application;

        //This method execute psc application, Only need to execute once
        public static Application launchPSC()
        {
            //Variable to open the test
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "iexplore.exe",
                Arguments = "https://wsx0038pa.theranos.local/QA.PSC.App/PSC.QA.application"
            };

            application = TestStack.White.Application.Launch(psi);
            Console.WriteLine("******************** Wait for 30 seconds for PSC to start ********************");
            Thread.Sleep(15000);
            return application;
        }
        
        //This function attach the PSC process to application
        public static Application attachPSC()
        {
            //Looking for PSC process          
           
            int thernosid = 0;
            Process[] procs = Process.GetProcesses();
            foreach (Process proc in procs)
            {
                if (proc.ProcessName == "PSC.QA")
                    thernosid = proc.Id;
            }

            application = TestStack.White.Application.Attach(thernosid);
            Console.WriteLine("Waiting for 5 seconds before attaching the process");
            Thread.Sleep(5000);
            return application;
        }

        //This process get Window of application
        public static pscWindow getWindow(TestStack.White.Application application)
        {
            WindowItems.Window pscWindow = application.GetWindow
                (SearchCriteria.ByText("Theranos.PSC"), InitializeOption.NoCache);

            Console.WriteLine("Application has been detected");
            return pscWindow;
        }
    }
}

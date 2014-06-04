using System;
using TestStack.White;
using System.Drawing;
using System.IO;

namespace PSCTest.core
{
    class Screenshot
    {
        private System.Drawing.Imaging.ImageFormat imageFormat = System.Drawing.Imaging.ImageFormat.Png;
        //Getting the screenshot of the desktop
        public void GetScreenshot(string filename)
        {
             string screenshotloc = GetScreenshotLocation(filename);             
             TestStack.White.Desktop.TakeScreenshot(screenshotloc,imageFormat);
        }

        //Getting the location of the screenshot
        public string GetScreenshotLocation(string filename)
        {
            string curloc = System.Environment.CurrentDirectory;
            string curtime = DateTime.Now.ToString("yyyyMMdd_HH_mm_ss");            
            string fileloc = Path.Combine(curloc, "..\\..\\logs\\screenshots\\"+curtime);
            if (!Directory.Exists(fileloc)) Directory.CreateDirectory(fileloc);
            return (Path.Combine(fileloc, filename));
        }

    }
}

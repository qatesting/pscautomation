using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PSCTest.core
{
    class ReadJson
    {
        string filename = null;
        public ReadJson(string filename)
        {
            this.filename = filename;
        }
        public string GetElementValue(string key)
        {
            string currentpath = System.Environment.CurrentDirectory;
            string fileloc = Path.Combine(currentpath, "..\\..\\utilities\\lookup\\" + filename);
            Console.WriteLine("Location of the File");
            Console.WriteLine(fileloc);

            string readfile = System.IO.File.ReadAllText(fileloc);
            JsonTextReader reader = new JsonTextReader(new StringReader(readfile));
            bool flag = false;
            while (reader.Read())
            {
                if (reader.Value != null)
                {
                    if (flag == true)
                    {
                        Console.WriteLine("Got the value of requested key");
                        flag = false;
                        return reader.Value.ToString();
                    }
                    Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                    string value = reader.Value.ToString();
                    if (value.ToLower().Equals(key.ToLower()))
                    {
                        flag = true;
                        continue;
                    }
                }
            }
            return null;
        }
    }
}

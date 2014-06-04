/*     //How to Access this class Data        
        {
            Test t = new Test();
            Dictionary<string, string> values = new Dictionary<string, string>();
            values = t.GetPatient("patientadditionalinfo.csv", 1);
            
            Console.WriteLine("Getting the values from main function");
            foreach (var innerKvp in values)
            {
                Console.WriteLine(innerKvp.Key + " " + innerKvp.Value);
            }                       
        }
*/


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSCTest.core
{
    class GetPatientData
    {
        //List of all the patient information save here
        List<Dictionary<int, Dictionary<string, string>>> patientsdata = null;
        public GetPatientData()
        {
            patientsdata = new List<Dictionary<int, Dictionary<string, string>>>();
        }        
        

        //This function read csv file and return list of dictionary with all patient information
        public bool ReadCSVFile(string filename)
        {
            List<string> tempdata = new List<string>();
            int datanum = 0;
            int idvalue = 0;
            int linenum = 0;

            //Getting the path of the file
            var patients = new Dictionary<int, Dictionary<string, string>>();
            //List<Dictionary<int, Dictionary<string, string>>> patientsdata = new List<Dictionary<int, Dictionary<string, string>>>();
            string curloc = System.Environment.CurrentDirectory;
            string fileloc = Path.Combine(curloc, "..\\..\\data\\" + filename);

            //Printing the value of file location
            //Read sample data from CSV file
            using (CsvFileReader reader = new CsvFileReader(fileloc))
            {
                CsvFileReader.CsvRow row = new CsvFileReader.CsvRow();
                while (reader.ReadRow(row))
                {
                    datanum = 0;
                    Dictionary<string, string> dic = new Dictionary<string, string>();
          
                    foreach (string s in row)
                    {
                        if (linenum == 0)
                        {
                            if (datanum > 0)
                                tempdata.Add(s);
                            datanum++;
                            continue;
                        }
                        else if (datanum == 0)
                            idvalue = Convert.ToInt32(s);
                        else
                        {
                            dic[tempdata[datanum - 1]] = s;
                        }                        
                        datanum++;
                    }
                    if (linenum > 0)
                    {
                        patients = GetData(idvalue, dic);
                        patientsdata.Add(patients);   
                    }                       
                    linenum++;
                }
            }
            return true;
        }
  
      //Link patient data with id 
      public Dictionary<int, Dictionary<string, string>> GetData(int key, Dictionary<string, string> data)
      {
        var patients = new Dictionary<int, Dictionary<string, string>>
        {
            {key, data }   
        };  
        return patients;
      }

    //Get the patient information using key
     public Dictionary<string,string> GetPatient(string filename, int key)
      {
         //Read given filename and save in the list of dictionary
          ReadCSVFile(filename);

          foreach (var patientvalue in patientsdata)
          {
              foreach (var kvp in patientvalue)
              {
                  var innerDict = kvp.Value;
                  if (key == kvp.Key)
                      return innerDict;                 
              }
          }         
          return null; 
      }

    //Get All the data from the file
    public List<Dictionary<int, Dictionary<string, string>>> GetAllData(string filename)
     {
         //Read given filename and save in the list of dictionary
         ReadCSVFile(filename);
         return patientsdata;
     }

    //Printing the values of List->Dictionary->Dictionary
    public void PrintFileData()
    {
        //Read all the values of the dictionary in the List
        Console.WriteLine("All Values from the patientinfo file");
        foreach (var patientvalue in patientsdata)
        {
            foreach (var kvp in patientvalue)
            {
                var innerDict = kvp.Value;
                foreach (var innerKvp in innerDict)
                {
                    Console.WriteLine(kvp.Key + " " + innerKvp.Key + " " + innerKvp.Value);
                }
            }
        }
     }
   }
}

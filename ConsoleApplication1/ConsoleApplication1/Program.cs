using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using CsvHelper;

namespace ConsoleApplication1
{
    class Program
    {
        public static DataTable jsonStringToTable(string jsonContent)
        {
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonContent);
            return dt;
        }
        public static string jsonToCSV(string jsonContent, string delimiter)
        {
            StringWriter csvString = new StringWriter();
            using (var csv = new CsvWriter(csvString))
            {
                csv.Configuration.SkipEmptyRecords = true;
                csv.Configuration.WillThrowOnMissingField = false;
                csv.Configuration.Delimiter = delimiter;

                using (var dt = jsonStringToTable(jsonContent))
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        csv.WriteField(column.ColumnName);
                    }
                    csv.NextRecord();

                    foreach (DataRow row in dt.Rows)
                    {
                        for (var i = 0; i < dt.Columns.Count; i++)
                        {
                            csv.WriteField(row[i]);
                        }
                        csv.NextRecord();
                    }
                }
            }
            return csvString.ToString();
        }
        static void Main(string[] args)
        {
            string path = @"C:\Users\Yusuf\Documents\Visual Studio 2013\Projects\ConsoleApplication1\ConsoleApplication1\equipments.json";
            path = path.Replace(@"\\", @"\");
            if( Path.HasExtension(path))
           {
               int c = 5;
           }
            StreamReader sr = File.OpenText(path);
            string json = sr.ReadToEnd();
            int x = 5;
        }
    }
}

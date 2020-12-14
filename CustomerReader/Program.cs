using CustomerReader.Extension;
using CustomerReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader
{
    class Program
    {
        private static readonly string filePath = "..\\..\\Files\\";

        public static void Main()
        {
            List<Customer> customerList = new List<Customer>();
            customerList.AddIntoCollection(CSVData.GetInstance().ReadDataFromFile(filePath + "customers.csv"));
            customerList.AddIntoCollection(XMLData.GetInstance().ReadDataFromFile(filePath + "customers.xml"));
            customerList.AddIntoCollection(JSONData.GetInstance().ReadDataFromFile(filePath + "customers.json"));

            if (customerList.Count > 0)
            {
                //Printing the count.
                Console.WriteLine("\n" + "Added this many customers: " + customerList.Count + "\n");
                //Printing the records.
                StringCorrection.DisplayRecords(customerList);
            }
        }
    }
}

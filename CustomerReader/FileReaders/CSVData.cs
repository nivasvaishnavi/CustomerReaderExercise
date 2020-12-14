using CustomerReader.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader
{
    public sealed class CSVData : CustomerData
    {
        private static readonly CSVData _mySingletonServiceInstance = new CSVData();

        public CSVData()
        {

        }

        public static CSVData GetInstance() => _mySingletonServiceInstance;

        public override List<Customer> ReadDataFromFile(String customerFilePath)
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                //Reading the file path and declaring a stream reader.
                using (StreamReader streamReader = new StreamReader(File.Open(customerFilePath, FileMode.Open)))
                {
                    //Initializing the stream reader to read the header line.
                    String line = streamReader.ReadLine();
                    String[] attributes;

                    //Checking if the header line is not empty to read next lines.
                    if (line != null)
                    {
                        //Reading the line next to the header.
                        line = streamReader.ReadLine();

                        //Checking if the lines preceeding header line are empty.
                        while (line != null)
                        {
                            attributes = line.Split(',');
                            customerList.Add(new Customer
                            {
                                Email = attributes[0],
                                FirstName = attributes[1],
                                LastName = attributes[2],
                                Phone = attributes[3],
                                StreetAddress = attributes[4],
                                City = attributes[5],
                                State = attributes[6],
                                ZipCode = attributes[7]
                            });
                            line = streamReader.ReadLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            return customerList;
        }
    }
}

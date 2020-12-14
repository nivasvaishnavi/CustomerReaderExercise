using CustomerReader.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader
{
    public sealed class JSONData : CustomerData
    {
        private static readonly JSONData _mySingletonServiceInstance = new JSONData();

        public JSONData()
        {

        }

        public static JSONData GetInstance() => _mySingletonServiceInstance;

        public override List<Customer> ReadDataFromFile(String customerFilePath)
        {
            List<Customer> customerList = new List<Customer>();
            
            //Initializing the Json text reader.
            JsonTextReader reader = new JsonTextReader(System.IO.File.OpenText(customerFilePath));
            try
            {
                //Reading content using the reader and storing in a Json array.
                JArray jArray = (JArray)JToken.ReadFrom(reader);

                //Loop for accessing every Json object from the Json array.
                foreach (JObject jObject in jArray)
                {
                    //Reading parent Json objects.
                    JObject record = jObject;
                    //Reading child Json objects.
                    JObject address = (JObject)record["Address"];
                    //Assigning the Json object values to a new Customer object property and adding it to the Customer List.
                    customerList.Add(new Customer
                    {
                        Email = (String)record["Email"],
                        FirstName = (String)record["FirstName"],
                        LastName = (String)record["LastName"],
                        Phone = (String)record["PhoneNumber"],
                        StreetAddress = (String)address["StreetAddress"],
                        City = (String)address["City"],
                        State = (String)address["State"],
                        ZipCode = (String)address["ZipCode"]
                    });
                }
            }
            catch (FileNotFoundException e)
            {
                Console.Write(e.StackTrace);
            }
            catch (IOException e)
            {
                Console.Write(e.StackTrace);
            }
            catch (JsonException e)
            {
                Console.Write(e.StackTrace);
            }
            return customerList;
        }
    }
}

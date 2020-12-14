using CustomerReader.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CustomerReader
{
    public sealed class XMLData : CustomerData
    {
        private static readonly XMLData _mySingletonServiceInstance = new XMLData();

        public XMLData()
        {

        }

        public static XMLData GetInstance() => _mySingletonServiceInstance;

        public override List<Customer> ReadDataFromFile(String customerFilePath)
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                var xmlDocument = new XmlDocument();
                //Reading the file path.
                xmlDocument.Load(customerFilePath);

                //Setting the tag name (Node) from which the data is to be read.
                XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/Customers/Customer");

                //Looping the records.
                foreach (XmlNode node in xmlNodeList)
                {
                    //Reading child nodes from each record.
                    XmlElement eElement = (XmlElement)node;
                    XmlElement aElement = (XmlElement)eElement.GetElementsByTagName("Address").Item(0);

                    //Assigning the node's inner text to a new Customer object property and adding it to the Customer List.
                    customerList.Add(new Customer
                    {
                        Email = node["Email"].InnerText,
                        FirstName = node["FirstName"].InnerText,
                        LastName = node["LastName"].InnerText,
                        Phone = node["PhoneNumber"].InnerText,

                        StreetAddress = aElement.GetElementsByTagName("StreetAddress")[0].InnerText,
                        City = aElement.GetElementsByTagName("City")[0].InnerText,
                        State = aElement.GetElementsByTagName("State")[0].InnerText,
                        ZipCode = aElement.GetElementsByTagName("ZipCode")[0].InnerText
                    });
                }
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            return customerList;
        }
    }
}

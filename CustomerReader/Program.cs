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
                customerList.DisplayRecords();
            }
        }
    }

    public static class ProgramHelper
    {
        public static void AddIntoCollection<T>(this IList<T> collection, IEnumerable<T> enumerable)
        {
            if (enumerable != null)
            {
                foreach (var cur in enumerable)
                {
                    if (cur != null)
                    {
                        collection.Add(cur);
                    }
                }
            }
        }

        public static string FirstLetterUpper(this string word)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(word))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(word[0]) + word.Substring(1);
        }

        public static string AllFirstLetterUpper(this string word)
        {
            char[] array = word.ToCharArray();
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }

        public static void DisplayRecords(this List<Customer> customerList)
        {
            foreach (Customer customer in customerList)
            {
                //Initializing a string variable and building it with values.
                StringBuilder customerString = new StringBuilder();
                customerString.AppendLine("Email: " + customer.Email.ToLower());
                customerString.AppendLine("First Name: " + customer.FirstName.Trim().FirstLetterUpper());
                customerString.AppendLine("Last Name: " + customer.LastName.Trim().FirstLetterUpper());
                customerString.AppendLine("Full Name: " + customer.FirstName.Trim().FirstLetterUpper() + " " + customer.LastName.Trim().FirstLetterUpper());
                customerString.AppendLine("Phone Number: " + customer.Phone);
                customerString.AppendLine("Street Address: " + customer.StreetAddress.AllFirstLetterUpper());
                customerString.AppendLine("City: " + customer.City.FirstLetterUpper());
                customerString.AppendLine("State: " + customer.State.ToUpper());
                customerString.AppendLine("Zip Code: " + customer.ZipCode);

                Console.WriteLine(customerString.ToString());
            }
        }
    }
}

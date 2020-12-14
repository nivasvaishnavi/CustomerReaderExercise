using CustomerReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Extension
{
    static class StringCorrection
    {
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

        public static void DisplayRecords(List<Customer> customerList)
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
                customerString.AppendLine("Street Address: " + customer.CustomerAddress.StreetAddress.AllFirstLetterUpper());
                customerString.AppendLine("City: " + customer.CustomerAddress.City.FirstLetterUpper());
                customerString.AppendLine("State: " + customer.CustomerAddress.State.ToUpper());
                customerString.AppendLine("Zip Code: " + customer.CustomerAddress.ZipCode);

                Console.WriteLine(customerString.ToString());
            }
        }
    }
}

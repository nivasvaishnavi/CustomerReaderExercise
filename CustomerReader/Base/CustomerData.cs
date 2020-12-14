using CustomerReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader
{
    public abstract class CustomerData
    {
        public abstract List<Customer> ReadDataFromFile(String customerFilePath);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerReader.Extension
{
    static class CustomerDataCollection
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
    }
}

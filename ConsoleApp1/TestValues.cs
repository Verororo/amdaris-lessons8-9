using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public delegate bool FilterDelegate(int value);

    internal class TestValues
    {
        public List<int> list;

        public List<int> filter(FilterDelegate predicate)
        {
            List<int> newList = new List<int>();
            foreach (int value in list)
            {
                if (predicate(value))
                {
                    newList.Add(value);
                }
            }

            return newList;
        }
    }
}

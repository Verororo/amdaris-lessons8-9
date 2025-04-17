using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class TestValuesExtension
    {
        public static int GetMax(this TestValues testValues)
        {
            return (testValues.list.Max());
        }
    }
}

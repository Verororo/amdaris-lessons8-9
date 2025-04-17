using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Entities
{
    internal class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Product { get; set; }
        public int Amount { get; set; }
    }
}

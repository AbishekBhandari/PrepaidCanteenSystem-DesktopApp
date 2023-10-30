using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_Management_System
{
    internal class Details
    {
        public int ID;
        public string Name;
        public byte[] Picture;
        public decimal Price;
        public int Quantity;
        public decimal Total;
        public string Category;
        public string Description;
        public string Active;

        public int SaleID;
        public DateTime SaleTime;
        public int SalesmanID;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Practice
{
    internal class Product
    {
        public int ProductId { get; set; }  
        public string ProductName { get; set; } 

        public Product(int productId, string productName)
        {
            ProductId = productId;
            ProductName = productName;
        }
        public override string ToString()
        {
            return $"ProductId: {ProductId} PrdouctName: {ProductName}";
        }
    }
}

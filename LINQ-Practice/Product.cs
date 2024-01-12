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

        public double ProductPrice { get; set; }
        public Product(int productId, string productName, double productPrice)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
        }
        public override string ToString()
        {
            return $"ProductId: {ProductId} PrdouctName: {ProductName} ProductPrice: {ProductPrice}";
        }
    }
}

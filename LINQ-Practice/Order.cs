using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Practice
{
    internal class Order
    {
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public string DeliveredDate { get; set; }
        public int CustomerId { get; set; } 
        public int ProductId { get; set; }

        public Order(int orderId, string orderDate, string deliveredDate, int customerId, int productId)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            DeliveredDate = deliveredDate;
            CustomerId = customerId;
            ProductId = productId;
        }

        public override string ToString()
        {
            return $"OrderId: {OrderId} OrderDate: {OrderDate} DeliveredDate: {DeliveredDate} CustomerId: {CustomerId} ProductId: {ProductId}";
        }
    }
}

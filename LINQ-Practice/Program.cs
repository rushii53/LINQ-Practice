using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
namespace LINQ_Practice
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //LINQ PRACTICE QUERIES
            string OrderDataFilePath = "./Database/ORDER_DATA.json";
            string PersonDataFilePath = "./Database/PERSON_DATA.json";
            string ProductDataFilePath = "./Database/PRODUCT_DATA.json";


            string ordersData = File.ReadAllText(OrderDataFilePath);
            string personData = File.ReadAllText(PersonDataFilePath);
            string productData = File.ReadAllText(ProductDataFilePath);

            List<Order> orders = JsonSerializer.Deserialize<List<Order>>(ordersData);
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(productData);
            List<Person> persons = JsonSerializer.Deserialize<List<Person>>(personData);



            //1
            //Get total Number of Persons
            int numberOfMales = persons.Count(person => person.Gender == "Male");
            int numberOfFemales = persons.Count(person => person.Gender == "Female");

            Console.WriteLine($"Number of Males: {numberOfMales}\t Number of Females: {numberOfFemales}");

            //2
            //Get Order Details in Month of Feb
            IEnumerable<Order> OrdersInMonthOfFeb = orders.Where(order =>
            {
                DateTime orderDate;
                if (DateTime.TryParseExact(order.OrderDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out orderDate))
                {
                    return orderDate.Month == 2;
                }
                return false;
            });
            foreach(Order order in OrdersInMonthOfFeb) { Console.WriteLine(order.ToString()); }


            //3
            //Get Persons details having age in range between 18 to 25
            IEnumerable<Person> PersonDetails = persons.Where(person => person.Age is >= 18 and <= 25);
            foreach(Person person in PersonDetails)
                Console.WriteLine(person);

            //4
            //To get ordered products having price greater than 400
            var OrderWithProduct = orders.Join(
                    products,
                    product => product.ProductId,
                    order => order.ProductId,
                    (order, product) => new
                    {
                        OrderId = order.OrderId,
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        productPrice = product.ProductPrice
                    }
                ).Where(product => product.productPrice is > 400);
            foreach (var order in OrderWithProduct)
                Console.WriteLine(order.ToString());

            //5
            //get product name and customer name, order by customers having age below 25
            var ProductOrderByPersonBelowAge_25 = orders.Join(
                    products,
                    order => order.ProductId,
                    product => product.ProductId,
                    (order, product) => new
                    {
                        OrderId = order.OrderId,
                        ProductName = product.ProductName,
                        PersonId = order.CustomerId
                    })
                .Join(
                    persons,
                    order => order.PersonId,
                    person => person.PersonId,
                    (order,person)=>new
                    {
                        CustomerName = person.FirstName+" "+person.LastName,
                        ProductName = order.ProductName,
                        Age = person.Age
                    }
                ).Where(person=>person.Age is < 25);


            foreach (var order in ProductOrderByPersonBelowAge_25)
                Console.WriteLine(order);


            //6
            //Product order by each customer with his name and product name
            var ProductOrderByCustomer = orders.Join(products,
                order => order.ProductId,
                product => product.ProductId,
                (order, product) => new { order.OrderId, order.CustomerId, product.ProductName }).Join(persons,
                order => order.CustomerId,
                person => person.PersonId,
                (order, p) => new { order.OrderId, FullName = p.FirstName + p.LastName, order.ProductName });


            foreach (var data in ProductOrderByCustomer)
                Console.WriteLine(data);

            //7
            //To get total count of orders by customers with their name
            var PersonsWithOrdersCount = orders.GroupBy(order => order.CustomerId)
                .Select(group => new { group.Key, TotalOrders = group.Count() })
                .Join(persons,
                group => group.Key,
                person => person.PersonId,
                (group, person) => new { PersonId = group.Key, FullName = person.FirstName + person.LastName, TotalOrders = group.TotalOrders }
                )
                .OrderBy(person=>person.PersonId);

            foreach ( var data in PersonsWithOrdersCount)
                Console.WriteLine(data);

            //8
            //Total revenue generated 
            var TotalRevenue = orders.Join(products,
                order => order.ProductId,
                product => product.ProductId,
                (order, product) => new { product.ProductPrice }).Sum(product=>product.ProductPrice);
            Console.WriteLine(TotalRevenue);


            Console.ReadLine();
        }
    }
}
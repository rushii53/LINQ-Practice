using Microsoft.VisualBasic;
using System;
using System.Globalization;
using System.Text.Json;
namespace LINQ_Practice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string OrderDataFilePath = "./Database/ORDER_DATA.json";
            string PersonDataFilePath = "./Database/PERSON_DATA.json";
            string ProductDataFilePath = "./Database/PRODUCT_DATA.json";


            string ordersData = File.ReadAllText(OrderDataFilePath);
            string personData = File.ReadAllText(PersonDataFilePath);
            string productData =File.ReadAllText(ProductDataFilePath);

            List<Order>orders = JsonSerializer.Deserialize<List<Order>>(ordersData);
            List<Product>products = JsonSerializer.Deserialize<List<Product>>(productData);
            List<Person>persons = JsonSerializer.Deserialize<List<Person>>(personData);

            //Get total Number of Persons
            int numberOfMales = persons.Count(person=>person.Gender=="Male");
            int numberOfFemales = persons.Count(person => person.Gender == "Female");

            Console.WriteLine($"Number of Males: {numberOfMales}\t Number of Females: {numberOfFemales}");

            
            //Get Order Details in Month of Feb

            IEnumerable<Order> ordersInFeb = orders.Where(order =>
            {
                DateTime orderDate;
                if (DateTime.TryParseExact(order.OrderDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out orderDate))
                {
                    return orderDate.Month == 2;
                }
                return false;
            });

            //foreach(Order order in ordersInFeb) { Console.WriteLine(order.ToString()); }

            //Get Persons details having age in range between 18 to 25
            IEnumerable<Person> personDetails = persons.Where(person => person.Age is >= 18 and <= 25);
            foreach(Person person in personDetails) { Console.WriteLine(person.ToString()); }

            var OrderWithProduct = orders.Join(
                    products,
                    product=>product.ProductId
                );
        }
    }
}
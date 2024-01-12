using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Practice
{
    internal class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public double Salary {  get; set; } 
        public Person(int personId, string firstName, string lastName, string gender, string address, int age, double salary)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Address = address;
            Age = age;
            Salary = salary;
        }

        public override string ToString()
        {
            return $"Id: {PersonId}\tFirstName: {FirstName}\t LastName: {LastName}\t Address: {Address}\t Gender: {Gender}\t Age: {Age}\t Salary: {Salary}";
        }
    }
}

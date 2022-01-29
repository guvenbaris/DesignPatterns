using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer
            {
                FirstName = "Engin",
                LastName = "Demiroğ",
                City = "Ankara",
                Id = 1 
            };

            // customer1 ve customer2 aynı nesneler değil 
            // new leme maliyeti oluşturmadan clone lamış olduk
            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Salih";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);
            Console.ReadLine();
        }
    }
    public abstract class Person
    {
        public abstract Person Clone();

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone(); // Clonelamak için
        }
    }
    public class Employee : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone(); // Clonelamak için
        }
    }
}

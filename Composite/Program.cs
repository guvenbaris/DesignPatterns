using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        // Nesnelerin hiyerarşisi
        static void Main(string[] args)
        {
            Employee engin = new Employee { Name = "Engin Demiroğ" };
            Employee salih = new Employee { Name = "Salih Demiroğ" };
            engin.AddSubordinate(salih);

            Employee derin = new Employee { Name = "Derin Demiroğ" };
            engin.AddSubordinate(derin);

            Employee ahmet = new Employee { Name = "Derin Demiroğ" };
            salih.AddSubordinate(ahmet);

            Console.WriteLine(engin.Name);
            foreach (Employee manager in engin)
            {
                Console.WriteLine(manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine(employee.Name);
                }
            }
            Console.ReadLine();
        }
    }
    interface IPerson
    {
        string Name { get; set; }
    }
    class Employee : IPerson,IEnumerable<IPerson>
    {
        public string Name { get; set; }
        List<IPerson> _subordinates = new List<IPerson>();
       public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        //for-each ile gezebileceğimiz pattern yaptık 
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

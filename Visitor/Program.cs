using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Genel olarak kullanımı: Birbirine benzeyen ya da hiyerarşik nesnelerin
            // aynı methodunun biri üzerinden diğerlerinin de çağırılması sürecidir...
            Manager engin = new Manager { Name = "Engin",Salary =1000};
            Manager salih = new Manager { Name = "Salih",Salary =900};

            Worker derin = new Worker { Name = "Derin", Salary = 800 };
            Worker ali = new Worker { Name = "Ali", Salary = 800 };

            engin.Subordinates.Add(salih);
            salih.Subordinates.Add(derin);
            salih.Subordinates.Add(ali);

            OrganizationalStructure organizational = new OrganizationalStructure(engin);
            PayrollVisitor payroll = new PayrollVisitor();
            Payrise payrise = new Payrise();

            organizational.Accept(payroll);
            organizational.Accept(payrise);
            Console.ReadLine();
            
        }
    }
    class OrganizationalStructure
    {
        public EmployeeBase Employee;
        public OrganizationalStructure(EmployeeBase firstEmployee)
        {
            Employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            Employee.Accept(visitor);
        }
    }
    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }
    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; } 
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }
    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }
    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }
    class PayrollVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}", worker.Name, worker.Salary);
        }
        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }

    class Payrise : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}",worker.Name,worker.Salary*(decimal) 1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary * (decimal)1.2);
        }
    }
}

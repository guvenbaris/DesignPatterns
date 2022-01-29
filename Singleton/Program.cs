using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            // Bir kere ü
           var customerManager =  CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }
    }
    class CustomerManager
    {
        // Bir kere ürettiğimizden emin oluyoruz varsa olanı döndür yoksa yenisini üret
        //private constructor tanımladık böylece dışarıdan erişilemiyor
        static CustomerManager _customerManager; //field
        static object _lockObject = new object();
        private CustomerManager()
        {
        }
        public static CustomerManager CreateAsSingleton()
        {
            lock (_lockObject) // kilit sistemi CustomerManager işleminin sadece bir kere
                               // olduğundan emin olmak istediğimiz için yapıyoruz                         
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
            //Kısa olarak yazım if blok
            // return _customerManager ?? (_customerManager = new CustomerManager());
        }
        public void Save()
        {
            Console.WriteLine("Saved!");
        }
    }
}


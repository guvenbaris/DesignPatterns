using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        // Farklı sistemleri kendi sistemlerimize entegre edilmesi durumunda 
        // kendi sistemimizin bozulmadan entegre edilen sistemin kendi sistemimiz gibi 
        // davranmasını sağlamktır.
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
            Console.ReadLine();
        }
    }
    class ProductManager
    {
        private ILogger _logger;
        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }
    interface ILogger
    {
        void Log(string message);
    }
    class EdLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged {0}",message);
        }
    }

    //Nugetten indirdik varsay
    public class Log4Net 
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with log4net{0}", message);
        }
    }
    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4net = new Log4Net();
            log4net.LogMessage(message);
        }
    }
}

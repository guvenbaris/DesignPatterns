using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new NhProductDal());
            productManager.Save();

            Console.ReadLine();
        }
    }

    interface IProductDal
    {
        void Save();
    }
    class EfProductDal:IProductDal 
    {
        public void Save()
        {
            Console.WriteLine("Saved with Ef");
        }
    }
    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with Ef");
        }
    }
    class ProductManager
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Save()
        {
            // Business Code
            _productDal.Save();
        }
    }
}

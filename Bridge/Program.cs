﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new SmsSender();
            customerManager.UpdateCustomer();
            Console.ReadLine();
        }
    }
   abstract class MessageSenderBase 
   {
        public void Save()
        {
            Console.WriteLine("Message saved");
        }
        public abstract void Send(Body body);
   }
    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender",body.Title);
        }
    }
    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via EmailSender", body.Title);
        }
    }
    //...
    class CustomerManager
    {
        internal MessageSenderBase MessageSenderBase { get; set; }

        public void UpdateCustomer()
        {
            Console.WriteLine("Customer updated");
            MessageSenderBase.Send(new Body { Title = "About the course"});
        }
    }
}

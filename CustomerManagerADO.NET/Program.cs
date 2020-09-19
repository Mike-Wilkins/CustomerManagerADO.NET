using CustomerManagerADO.NET.CustomerLogic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CustomerManagerADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer();
            var create = new Customers();
            create.PrintCustomers();
            Console.ReadLine();
            Console.Clear();

            //Create new Customer

            //customer.FirstName = "Zak";
            //customer.MiddleName = "David";
            //customer.LastName = "Roberts";
            //customer.PhoneNumber = 890003;
            //customer.Address = "9 Oak Avenue";
            //customer.Email = "peter@gmail.com";
            //customer.DateCreated = DateTime.Now.ToShortDateString();


            //create.Create(customer);

            //Console.ReadLine();
            //create.PrintCustomers();




            // Delete Customer
            //var delete = new Customers();
            //delete.Delete("Rob");


            // Update Customer Details
            //customer.FirstName = "James";
            //customer.MiddleName = "William";
            //customer.LastName = "Taylor";
            //customer.PhoneNumber = 883885;
            //customer.Address = "109 Grange Close";
            //customer.Email = "james@gmail.com";
            //customer.DateCreated = DateTime.Now.ToShortDateString();

            //create.Edit(customer);

            //Console.ReadLine();

            //create.PrintCustomers();



        }
    }
}

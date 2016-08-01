using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFfromDB.Models;


namespace EFfromDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\nTesting START:\n");

            using (var db = new APIAppDbContext())
            {
                
                //1
                Console.WriteLine("\n1.Select all customers whose name starts with letter 'D' ");
                var customersLikeD = db.Customers
                                        .Where(c => c.ContactName.StartsWith("D"))
                                        .ToList();
                foreach (var customer in customersLikeD)
                {
                    Console.WriteLine("Customer Name : {0}", customer.ContactName);
                }

                //2
                Console.WriteLine("\n2.Convert names of all customers to Upper Case ");
                var query = from cust in db.Customers
                            orderby cust.ContactName
                            select new { ContactName = cust.ContactName.ToUpper() };
                foreach (var item in query)
                {
                    Console.WriteLine("Contact name = {0}", item.ContactName);
                }

                //3
                Console.WriteLine("\n3.Select distinct country from Customers ");
                var countryNames = (from сustomer in db.Customers select сustomer.Country ).Distinct();
                Console.WriteLine("Countries: ");
                foreach (var item in countryNames)
                {
                    Console.WriteLine(" - {0}", item);
                }

                //4
                Console.WriteLine("\n4.Select Contact name from Customers Table from Lindon and title like 'Sales' ");
                var customersFromLondon = db.Customers
                                            .Where(c => c.ContactTitle.StartsWith("Sales"))
                                            .Where(c => c.City == "London")
                                            .ToList();
                foreach (var customer in customersFromLondon)
                {
                    Console.WriteLine(" - {0}", customer.ContactName);
                }

                //5
                Console.WriteLine("\n5.Select all orders id where was bought 'Tofu' ");
                var selectTofuOrders = (
                                       from p in db.Products
                                       from od in db.OrderDetails
                                       where p.ProductName == "Tofu" && p.ProductId == od.ProductId
                                       select new { od.OrderId });
                foreach (var order in selectTofuOrders)
                {
                    Console.WriteLine(" - {0}", order);
                }

                //6
                Console.WriteLine("\n6.Select all product names that were shipped to Germany ");
                var germanyProducts = (from p in db.Products
                                      from od in db.OrderDetails
                                      from o in db.Orders
                                      where p.ProductId == od.ProductId && od.OrderId == o.OrderId && o.ShipCountry == "Germany"
                                      select new { p.ProductName }).Distinct();
                foreach (var product in germanyProducts)
                {
                    Console.WriteLine(" - {0}", product);
                }
                
                //7
                Console.WriteLine("\n7.Select all customers that ordered 'Ikura' ");
                var selectIcuraOrders = (from customer in db.Customers
                                         from order in customer.Orders
                                         from od in order.OrderDetails
                                         from p in db.Products
                                         where p.ProductName == "Ikura" && p.ProductId == od.ProductId
                                         select new { customer.ContactName }).Distinct();
                foreach (var name in selectIcuraOrders)
                {
                    Console.WriteLine(" - {0}", name.ContactName);
                }
                
                //8
                Console.WriteLine("\n8.Select all employees and any orders they might have ");
                var q =
                        from e in db.Employees
                        join o in db.Orders on e.EmployeeId equals o.EmployeeId 
                        into ps
                        from o in ps.DefaultIfEmpty()
                        select new { Name = e.FirstName,Surename = e.LastName , OrderId = o.OrderId };
                foreach (var v in q)
                {
                    Console.WriteLine(v.Name + " " + v.Surename +" - "+ v.OrderId);
                }

                //9
                Console.WriteLine("\n9.Selects all employees, and all orders ");
                var rightJoin =
                        from o in db.Orders
                        join e in db.Employees on o.EmployeeId equals e.EmployeeId
                        into ps
                        from e in ps.DefaultIfEmpty()
                        select new { Name = e.FirstName, Surename = e.LastName, OrderId = o.OrderId };
                foreach (var v in rightJoin )
                {
                    Console.WriteLine(v.Name + " " + v.Surename + " - " + v.OrderId);
                }
                
                //10
                Console.WriteLine("\n10.Select all phones from Shippers and Suppliers ");
                var supliers = from sp in db.Suppliers select sp.Phone;
                var shippers = from sh in db.Shippers select sh.Phone;
                var Phones = supliers.Union(shippers);

                Console.WriteLine("Phones: ");
                foreach (var phone in Phones)
                {
                    Console.WriteLine(" - {0}",phone );
                }
                


            }//using
            Console.WriteLine("\nSuccess! End.");
        }//manin

    }//class program
}

using lab_3.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> user = new List<Product>();
            int option;
            do
            {
                Console.Clear();
                option = menu();
                if (option == 1)
                {
                    user.Add(addData());
                }
                else if (option == 2)
                {
                    viewProduct(user);
                }
                else if (option == 3)
                {
                    highestprice(user);
                }
                else if (option == 4)
                {
                    viewSalesTax(user);
                }
                else if (option == 5)
                {
                    productsToBeOrdered(user);
                }
            }
            while (option < 6);
            Console.ReadKey();
        }
        static int menu()
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View all Products");
            Console.WriteLine("3. Product With highest Price");
            Console.WriteLine("4. View sales tax of all Product");
            Console.WriteLine("5. Product to be odered(less than threshold)");
            Console.WriteLine("6. Exit");
            Console.WriteLine(" Enter Option: ");
            int op = int.Parse(Console.ReadLine());
            return op;
        }
        static Product addData()
        {
            Console.Clear();
            Product user = new Product();
            Console.WriteLine("Enter the Product name: ");
            user.productName = Console.ReadLine();
            Console.WriteLine("Enter the Product Category: ");
            user.productCategory = Console.ReadLine();
            Console.WriteLine("Enter the Product Price: ");
            user.productPrice = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Product stock quantity: ");
            user.stockQuantity = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Product minimum stock: ");
            user.minimumStock = float.Parse(Console.ReadLine());
            Console.ReadKey();
            return user;
        }
        static void viewProduct(List<Product> user)
        {
            Console.Clear();
            Console.WriteLine("All Products!!  ");
            for (int i = 0; i < user.Count; i++)
            {
                Console.WriteLine(user[i].productName + "\t" + user[i].productCategory + "\t" + user[i].productPrice + "\t" + user[i].stockQuantity + "\t" + user[i].minimumStock);
            }

            Console.ReadKey();
        }
        static int highest(List<Product> user)
        {
            int idx = 0;
            for (int i = 0; i < user.Count; i++)
            {
                if (user[i + 1].productPrice > user[i].productPrice)
                {
                    idx = i + 1;
                }
            }
            return idx;
        }
        static void highestprice(List<Product> user)
        {
            int idx = highest(user);
            Console.WriteLine(user[idx].productName + "\t" + user[idx].productPrice + "\t" + user[idx].productCategory);
            Console.ReadKey();
        }
        static void viewSalesTax(List<Product> p)
        {
            Console.Clear();
            Console.WriteLine("Sales Tax....");
            float tax = 0;
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].productCategory == "Grocery" || p[i].productCategory == "grocery")
                {
                    tax = (float)(p[i].productPrice * 0.1);
                    Console.WriteLine("{0}\t{1}", p[i].productName, tax);
                }
                else if (p[i].productCategory == "Fruit" || p[i].productCategory == "fruit")
                {
                    tax = (float)(p[i].productPrice * 0.05);
                    Console.WriteLine("{0}\t{1}", p[i].productName, tax);
                }
                else
                {
                    tax = (float)(p[i].productPrice * 0.15);
                    Console.WriteLine("{0}\t{1}", p[i].productName, tax);
                }
            }
            Console.ReadKey();
        }
        static void productsToBeOrdered(List<Product> p)
        {
            Console.Clear();
            Console.WriteLine("Products To be Ordeded.....");
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].stockQuantity < p[i].minimumStock)
                {
                    Console.WriteLine(p[i].productName);
                }
            }
            Console.ReadKey();


        }
    }
}
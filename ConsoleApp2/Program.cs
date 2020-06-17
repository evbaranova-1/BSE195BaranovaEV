using BookstoreLibrary;
using BSE195BaranovaEV;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Bookstore<Product> books = new Bookstore<Product>();
                try
                { 
                    using (FileStream fs = new FileStream(@"../../../books.json", FileMode.Open))
                    {

                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Bookstore<Product>),
                        new Type[] { typeof(Book), typeof(Product) });
                        books = (Bookstore<Product>)jsonSerializer.ReadObject(fs);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("проблемы" + e.Message);
                }

                foreach (var item in books)
                {
                    Console.WriteLine(item);
                }
                books.Remove();

                var linq = from book in books
                           where ((Book)book).Year == books.Max(x =>((Book)x).Year)
                           select book;

                Console.WriteLine("3 линк: ");
                foreach (var item in linq)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine($"Размер = {linq.Count()}");
                Console.WriteLine();

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}

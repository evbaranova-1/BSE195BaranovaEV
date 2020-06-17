using BookstoreLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace BSE195BaranovaEV
{
    class Program
    {
        public static Random rnd = new Random();

        static int Read()
        {
            int n;
            Console.Write($"Введите N ");

            while (!int.TryParse(Console.ReadLine(), out n) && n <= 0)
            {
                Console.WriteLine($"N должно быть больше нуля");
            }
            return n;
        }

        static string Check1()
        {
            string str = "";
            for (int i = 0; i < rnd.Next(3, 16); i++)
            {
                int numb;
                numb = rnd.Next(0, 3);
                switch (numb)
                {
                    case 0:
                        str += $"{(char)rnd.Next('a', 'z' + 1)}";
                        break;
                    case 1:
                        str += $"{(char)rnd.Next('A', 'Z' + 1)}";
                        break;
                    case 2:
                        str += " ";
                        break;
                }

            }
            return str;
        }

        static void SerializeBookstoreJson(string path, Bookstore<Product> products)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Bookstore<Product>));
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    jsonSerializer.WriteObject(fs, products);
                }

                Console.WriteLine("JSON ок");
            }
            catch (Exception e)
            {
                Console.WriteLine($"JSON не ок {e.Message}");
            }
        }

        static void Main(string[] args)
        {

            do
            {
                Bookstore<Product> books = new Bookstore<Product>();

                int n = Read();
                for (int i = 0; i < n; i++)
                {
                    try
                    {
                        books.Add(new Book()
                        {
                            Price = rnd.NextDouble() * 20,
                            NumberOfPages = (short)rnd.Next(0, 701),
                            Year = (short)rnd.Next(1980, 2030),
                            Title = Check1(),
                            Rating = rnd.NextDouble() * ((7 + 2) - 2)
                        });
                    }
                    catch (Exception)
                    {
                        --i;
                    }
                }

                books.Add(new Product() { Price = 1, Title = "Товар1" });

                foreach (var item in books)
                {
                    Console.WriteLine(item);
                }

                try
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Bookstore<Product>), new Type[] { typeof(Book), typeof(Product) } );
                    using (FileStream fs = new FileStream(@"../../../books.json", FileMode.OpenOrCreate))
                    {
                        jsonSerializer.WriteObject(fs, books);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"JSON не ок {ex.Message}");
                }
                

                Console.WriteLine("Нажмите escape для выхода");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}




using System;

namespace dotnet_core_postgres_code_first
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Models;

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CreateData();
                ReadData();
                DeleteData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }

        static void CreateData()
        {
            var context = new EFContext();

            var author = new Author
            {
                FirstName = "Richard",
                LastName = "Morgan"
            };

            context.Authors.Add(author);

            context.Books.AddRange(new List<Book>
            {
                new Book
                {
                    Title = "Broken Angels",
                    Author = author
                },
                new Book
                {
                    Title = "Black Man",
                    Author = author
                }
            });

            var rowsAffected = context.SaveChanges();

            if (rowsAffected == 0)
            {
                Console.WriteLine("Data created");
            }
        }

        static void ReadData()
        {
            var context = new EFContext();

            var books = context.Books
                .Include(b => b.Author).ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author.FirstName} {book.Author.LastName}");
            }
        }

        static void DeleteData()
        {
            var context = new EFContext();

            context.Books.RemoveRange(context.Books.ToList());
            context.Authors.RemoveRange(context.Authors.ToList());

            context.SaveChanges();
        }
    }
}

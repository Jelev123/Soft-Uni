using System;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;

namespace BookShop
{
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);
            //var input = Console.ReadLine();

            int intt = int.Parse(Console.ReadLine());

            var result = GetBooksNotReleasedIn(db,intt);

            Console.WriteLine(result);
        }

        // 1. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var book = context.Books
                .AsEnumerable()
                .Where(s => s.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(s=>s.Title)
                .OrderBy(s => s)
                .ToList();

            return String.Join(Environment.NewLine, book);
        }

        // 2. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {

            var sb = new StringBuilder();
            var book = context.Books
                .Select(s => new
                {
                    s.BookId,
                    s.Copies,
                    s.Title,
                    s.EditionType
                })
                .Where(s => s.Copies < 5000 && s.EditionType == EditionType.Gold)
                .OrderBy(s => s.BookId)
                .ToList();


            foreach (var b in book)
            {
                sb.AppendLine($"{b.Title}");
            }

            return sb.ToString().TrimEnd();

        }


        // 3. Books by Price

        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var book = context.Books
                .Where(s => s.Price > 40)
                .Select(s => new
                {
                    s.Price,
                    s.Title
                })
                .OrderByDescending(s => s.Price)
                .ToList();
               

            foreach (var b in book)
            {
                sb.AppendLine($"{b.Title} - ${b.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        // 4. Not Released In


        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var book = context.Books
                .Where(s => s.ReleaseDate.Value.Year != year)
                .Select(s => s.Title)
                .ToList();

            return string.Join(Environment.NewLine, book);
        }
    }
}

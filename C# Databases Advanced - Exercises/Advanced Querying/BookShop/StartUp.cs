using System;
using System.Linq;

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
            var input = Console.ReadLine();

            var result = GetBooksByAgeRestriction(db, input);

            Console.WriteLine(result);
        }


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
    }
}

using System;
using System.Globalization;
using System.Linq;
using System.Text;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore.Internal;

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

            //int intt = int.Parse(Console.ReadLine());

            var result = GetMostRecentBooks(db);

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
                .Select(s => new
                {
                    s.Price,
                    s.Title
                })
                .Where(s => s.Price > 40)
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



        //  6. Released Before Date

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            var book = context.Books
                .ToList()
                .Select(s => new
                {
                    s.Title,
                    s.EditionType,
                    s.Price,
                    s.ReleaseDate
                })
                .Where(s => DateTime.Parse(s.ReleaseDate.ToString()) < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                .OrderByDescending(s => s.ReleaseDate)
                .ToList();


            foreach (var b in book)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }




        // 7. Author Search


        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            
            var author = context.Authors
                .ToList()
                .Select(s => new
                {
                    FullName = s.FirstName + " " + s.LastName,
                    s.FirstName
                })
                .Where(s => s.FirstName.ToLower().EndsWith(input.ToLower()))
                .OrderBy(s=>s.FullName)
                .ToList();

            foreach (var a in author)
            {
                sb.AppendLine(a.FullName);
            }

            return sb.ToString().TrimEnd();
        }



        //8. Book Search


        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var book = context.Books
                .Where(s => s.Title.ToLower().Contains(input.ToLower()))
                .Select(s => s.Title)
                .OrderBy(s => s)
                .ToList();

            return String.Join(Environment.NewLine,book);
        }


        // 9. Book Search by Author


        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var book = context.Books
                .Select(s => new
                {
                    s.Title,
                    FullName = s.Author.FirstName + " " + s.Author.LastName,
                   LastName= s.Author.LastName,
                    s.BookId
                })
                .Where(s => s.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(s => s.BookId)
                .ToList();

            foreach (var b in book)
            {
                sb.AppendLine($"{b.Title} ({b.FullName})");
            }

            return sb.ToString().TrimEnd();
        }



        // 10. Count Books

         public static int CountBooks(BookShopContext context, int lengthCheck)
         {
            int counter = context.Books
                .Where(x => x.Title.Length > lengthCheck).Count();

            return counter;
        }



        // 11. Total Book Copies




        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context.Authors
                .Select(s => new
                {
                    FullName = s.FirstName + " " + s.LastName,
                    totalCopies = s.Books.Select(s => s.Copies).Sum()
                })
                .OrderByDescending(s => s.totalCopies).ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.FullName} - {book.totalCopies}");
            }

            return sb.ToString().TrimEnd();
        }


        // 12. Profit by Category



        public static string GetTotalProfitByCategory(BookShopContext context)
        {

            var sb = new StringBuilder();

            var books = context.Categories
                
                .Select(s => new
                {
                    CategoryName = s.Name,
                    totalProfit =s.CategoryBooks.Select(s=>s.Book.Copies * s.Book.Price).Sum()
                })
                .OrderByDescending(s=>s.totalProfit)
                .ThenBy(s=>s.CategoryName)
                .ToList();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.CategoryName} ${book.totalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 13. Most Recent Books

        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks.Select(x => new {
                            BookTitle = x.Book.Title,
                            BookReleaseDate = x.Book.ReleaseDate
                        })
                        .OrderByDescending(x => x.BookReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookReleaseDate.Value.Year})");
                }

            }

            return sb.ToString().TrimEnd();
        }



        // 14. Increase Prices

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books;

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        // 15. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);

            var result = context.SaveChanges();

            return result / 2;
        }
    }
}

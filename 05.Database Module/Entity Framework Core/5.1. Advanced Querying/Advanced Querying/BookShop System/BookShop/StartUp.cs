namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static StringBuilder sb = new StringBuilder();
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //Task 1 -> Console.WriteLine(GetBooksByAgeRestriction(db, "miNor"));
            //Task 2 -> Console.WriteLine(GetGoldenBooks(db));
            //Task 3 -> Console.WriteLine(GetBooksByPrice(db));
            //Task 4 -> Console.WriteLine(GetBooksNotReleasedIn(db, 2000));
            //Task 5 -> Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));
            //Task 6 -> Console.WriteLine(GetBooksReleasedBefore(db, "12-04-1992"));
            //Task 7 -> Console.WriteLine(GetAuthorNamesEndingIn(db, "e"));
            //Task 8 -> Console.WriteLine(GetBookTitlesContaining(db, "SK"));
            //Task 9 -> Console.WriteLine(GetBooksByAuthor(db, "R"));
            //Task 10 -> Console.WriteLine(CountBooks(db, 12));
            //Task 11 -> Console.WriteLine(CountCopiesByAuthor(db));
            //Task 12 -> Console.WriteLine(GetTotalProfitByCategory(db));
            //Task 13 -> Console.WriteLine(GetMostRecentBooks(db));
            Console.WriteLine(RemoveBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);
            var books = context.Books
                   .Where(b => b.AgeRestriction == ageRestriction)
                   .Select(b => b.Title)
                   .OrderBy(t => t)
                   .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBooks = context.Books
                    .Where(b => b.Copies < 5000 &&
                                b.EditionType == EditionType.Gold)
                    .Select(b => new Book
                    {
                        Title = b.Title,
                        BookId = b.BookId
                    })
                    .OrderBy(b => b.BookId)
                    .ToArray();

            return String.Join(Environment.NewLine, goldenBooks
                                                        .Select(x => x.Title));
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            sb.Clear();

            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new { Title = b.Title, Price = b.Price })
                .OrderByDescending(b => b.Price)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new { Title = b.Title, BookId = b.BookId })
                .OrderBy(b => b.BookId)
                .ToArray();

            return String.Join(Environment.NewLine, books.Select(x => x.Title));
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower());

            var books = context.Books
                .Where(b => b.BookCategories
                                .Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetReleasesDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = context.Books
                         .Where(b => b.ReleaseDate.Value < targetReleasesDate)
                         .Select(b => new
                         {
                             Title = b.Title,
                             EditionType = b.EditionType,
                             ReleaseDate = b.ReleaseDate.Value,
                             Price = b.Price
                         })
                         .OrderByDescending(b => b.ReleaseDate)
                         .ToArray();

            return String.Join(Environment.NewLine, books
                                        .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));


        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            //Return the full names of authors, whose first name ends with a given string.
            //Return all names in a single string, each on a new row, ordered alphabetically
            var authors = context.Authors
                            .Where(a => a.FirstName.EndsWith(input))
                            .Select(a => new { FullName = a.FirstName + " " + a.LastName })
                            .OrderBy(a => a.FullName)
                            .ToArray();

            return String.Join(Environment.NewLine, authors.Select(x => x.FullName));
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            //Return the titles of book, which contain a given string. Ignore casing.
            //Return all titles in a single string, each on a new row, ordered alphabetically.
            var books = context.Books
                        .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                        .Select(b => b.Title)
                        .OrderBy(b => b)
                        .ToArray();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            //Return all titles of books and their authors’ names for books,
            //which are written by authors whose last names start with the given string.
            //Return a single string with each title on a new row.Ignore casing.Order by book id ascending.

            var books = context.Books
                        .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                        .Select(b => new
                        {
                            Title = b.Title,
                            Author = b.Author.FirstName + " " + b.Author.LastName,
                            BookId = b.BookId
                        })
                        .OrderBy(b => b.BookId)
                        .ToArray();

            return String.Join(Environment.NewLine, books
                                                    .Select(b => $"{b.Title} ({b.Author})"));
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            //Return the number of books, which have a title longer than the number given as an input.
            var books = context.Books
                            .Where(b => b.Title.Length > lengthCheck)
                            .Select(b => b.Title)
                            .Count();

            return books;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            //Return the total number of book copies for each author. Order the results descending by total book copies.
            //Return all results in a single string, each on a new line.
            var authors = context.Authors
                            .Select(a => new
                            {
                                FullName = $"{a.FirstName} {a.LastName}",
                                Copies = a.Books.Select(b => b.Copies).Sum()
                            })
                            .OrderByDescending(b => b.Copies);

            return string.Join(Environment.NewLine, authors.Select(a => $"{a.FullName} - {a.Copies}"));
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            //Return the total profit of all books by category.
            //Profit for a book can be calculated by multiplying its number of copies by the price per single book.
            //Order the results by descending by total profit for category and ascending by category name.
            //Art $6428917.79
            var categories = context.Categories
                        .Select(c => new
                        {
                            CategoryName = c.Name,
                            Profit = c.CategoryBooks.Sum(x => x.Book.Copies * x.Book.Price)
                        })
                        .OrderByDescending(c => c.Profit)
                        .ThenBy(c => c.CategoryName)
                        .ToArray();


            return String.Join(Environment.NewLine, categories.Select(c => $"{c.CategoryName} ${c.Profit:F2}"));
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            //Get the most recent books by categories. The categories should be ordered by name alphabetically.
            //Only take the top 3 most recent books from each category - ordered by release date (descending).
            //Select and print the category name, and for each book – its title and release year.

            var categories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    RecentBooks = c.CategoryBooks
                                        .Select(x => x.Book)
                                        .OrderByDescending(x => x.ReleaseDate.Value)
                                        .Take(3),
                })
                .OrderBy(c => c.CategoryName)
                .ToArray();

            sb.Clear();
            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var recentBook in category.RecentBooks)
                {
                    sb.AppendLine($"{recentBook.Title} ({recentBook.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            //Increase the prices of all books released before 2010 by 5.
            context.Books
                    .Where(b => b.ReleaseDate.Value.Year < 2010)
                    .ToList()
                    .ForEach(b => b.Price += 5);
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);

            context.SaveChanges();

            return books.Count();
        }
    }
}

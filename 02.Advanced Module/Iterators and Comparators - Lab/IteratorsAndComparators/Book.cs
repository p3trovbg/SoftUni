using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public IReadOnlyList<string> authors { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }


        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            this.authors = authors.ToList();
        }

        public int CompareTo(Book other)
        {
            int result = Year.CompareTo(other.Year);
            if (result == 0)
            {
                return Title.CompareTo(other.Title);
            }
            return result;
        }
        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}

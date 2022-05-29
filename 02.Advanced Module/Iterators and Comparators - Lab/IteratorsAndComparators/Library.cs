using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private readonly SortedSet<Book> books;
        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books, new BookComparator());
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(IReadOnlyCollection<Book> books)
            {
                Reset();
                this.books = new List<Book>(books);
            }

            public Book Current => books[currentIndex];

            object IEnumerator.Current => this.Current;

            public bool MoveNext()
            {
                currentIndex++;
                return currentIndex < books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
            public void Dispose()
            {
            }
        }
    }
}

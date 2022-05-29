using System;

namespace _02._Articles
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            //Add properties in the class.
            Article article = new Article(input[0], input[1], input[2]);

            //Read rotations about for loop.
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string operation = commands[0];
                string variation = commands[1];
                if (operation == "Edit")
                {
                    article.Edit(variation);
                }
                else if (operation == "ChangeAuthor")
                {
                    article.ChangeAuthor(variation);
                }
                else if (operation == "Rename")
                {
                    article.Rename(variation);
                }
            }

            Console.WriteLine(article);
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace _03._Articles_2._0
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

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

        class Program
        {
            static void Main(string[] args)
            {
                int rotations = int.Parse(Console.ReadLine());
                List<Article> collect = new List<Article>();
                for (int i = 0; i < rotations; i++)
                {
                    string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                    Article currentArticle = new Article(input[0], input[1], input[2]);

                    collect.Add(currentArticle);
                }

                string type = Console.ReadLine();
                if (type == "title")
                {
                    List<Article> result = collect.OrderBy(x => x.Title).ToList();
                    foreach (var item in result)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (type == "content")
                {
                    List<Article> result = collect.OrderBy(x => x.Content).ToList();
                    foreach (var item in result)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (type == "author")
                {
                    List<Article> result = collect.OrderBy(x => x.Author).ToList();
                    foreach (var item in result)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
}


using System;
using System.Security.Cryptography;
using System.Text;

namespace _05._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            //head
            //article
            //while -> input == end of comments
            //   - read input and put in <div> input </div>
            var sb = new StringBuilder();
            string head = Console.ReadLine();
            sb.AppendLine("<h1>");
            sb.AppendLine($"    {head}");
            sb.AppendLine("</h1>");
            string article = Console.ReadLine();
            sb.AppendLine("<article>");
            sb.AppendLine($"    {article}");
            sb.AppendLine("</article>");

            while (true)
            {
                string comment = Console.ReadLine();
                if (comment == "end of comments")
                {
                    break;
                }
                sb.AppendLine("<div>");
                sb.AppendLine($"    {comment}");
                sb.AppendLine("</div>");

            }

            Console.WriteLine(sb);
        }
    }
}

using System;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split(new string[] {" " , ", " } ,StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<string>(info[1..]);
            while ((info[0] = Console.ReadLine()) != "END")
            {
                switch (info[0])
                {
                    case "Push":
                        stack.Push(info[1]);
                        break;
                    case "Pop":
                        stack.Pop();
                        break;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}

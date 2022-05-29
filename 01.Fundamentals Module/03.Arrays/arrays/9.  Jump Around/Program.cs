using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.__Jump_Around
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            //•	"Collect - {item}" – Receiving this command, you should add the given item in your inventory. If the item already exists, you should skip this line.
            //•	"Drop - {item}" – You should remove the item from your inventory, if it exists.
            //•	"Combine Items - {oldItem}:{newItem}" – You should check if the old item exists, if so, add the new item after the old one. Otherwise, ignore the command.
            //•	"Renew – {item}" – If the given item exists, you should change its position and put it last in your inventory
            List<string> myList = new List<string>(items);
            bool flag = false;
            string[] element = new string[2];
            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string oldItem = "";
                string newItem = "";
                if (commands[0] == "Craft!")
                {
                    break;
                }
                else if (commands[0] == "Combine Items")
                {
                    element = commands[1].Split(":");
                    oldItem = element[0];
                    newItem = element[1];
                }

                foreach (string elements in myList)
                {
                    if (elements == commands[1] || elements == oldItem)
                    {
                        flag = true;
                        break;
                    }
                }
                if (commands[0] == "Collect" && !flag)
                {
                    myList.Add(commands[1]);
                }
                else if (commands[0] == "Drop" && flag)
                {
                    myList.Remove(commands[1]);
                }
                else if (commands[0] == "Combine Items" && flag)
                {
                    myList.Insert(myList.IndexOf(oldItem), newItem);

                }
                else if (commands[0] == "Renew" && flag)
                {
                    myList.Remove(myList.FindLastIndex(myList));
                    myList.Insert( myList.Count,commands[1]);
                }

            }

            Console.WriteLine(string.Join(", ", myList));
            
        }
    }
}


using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            var lessons = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "course start")
                {
                    break;
                }

                string[] commands = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string operation = commands[0];
                string lesson = commands[1];
                //Добавяме елемент
                if (operation == "Add")
                {
                    if (lessons.Contains(lesson))
                    {
                        continue;
                    }

                    lessons.Add(lesson);
                }
                //Вмъкваме елемент
                else if (operation == "Insert")
                {
                    int index = int.Parse(commands[2]);
                    if (lessons.Contains(lesson) && index >= 0 && index < lessons.Count)
                    {
                        continue;
                    }
                    lessons.Insert(index, lesson);
                }
                //Премахваме елемент, ако има такъв
                else if (operation == "Remove")
                {
                    if (lessons.Contains(lesson))
                    {
                        lessons.Remove(lesson);
                    }
                    else
                    {
                        continue;
                    }
                }
                //Разменяме местата на елементите
                else if (operation == "Swap")
                {
                    string lessonTitle1 = commands[1];
                    string lessonTitle2 = commands[2];
                    int index1 = lessons.IndexOf(lessonTitle1);
                    int index2 = lessons.IndexOf(lessonTitle2);
                    if (lessons.Contains(lessonTitle1) && lessons.Contains(lessonTitle2))
                    {
                        string tempLessonTitle1 = lessons.ElementAt(index1);
                        lessons[index1] = lessons[index2];
                        lessons[index2] = tempLessonTitle1;

                    }
                    else
                    {
                        continue;
                    }
                    if (lessons.Contains(lessonTitle1 + "-Exercise") && lessons.Contains(lessons[index1]))
                    {
                        index1 = lessons.IndexOf(lessonTitle1);
                        lessons.Remove(lessonTitle1 + "-Exercise");
                        lessons.Insert(index1 + 1, lessonTitle1 + "-Exercise");
                    }
                    else if (lessons.Contains(lessonTitle2 + "-Exercise") && lessons.Contains(lessons[index2]))
                    {
                        index2 = lessons.IndexOf(lessonTitle2);
                        lessons.Remove(lessonTitle2 + "-Exercise");
                        lessons.Insert(index2 + 1, lessonTitle2 + "-Exercise");
                    }
                    else
                    {
                        continue;
                    }
                }
                //Добавяме упражнение към урок
                else if (operation == "Exercise")
                {
                    string exercise = $"{lesson}-Exercise";
                    if (lessons.Contains(lesson) && !lessons.Contains(lesson + "-Exercise"))
                    {
                        int idx = lessons.IndexOf(lesson);
                        lessons.Insert(idx + 1, exercise);
                    }
                    else if (!lessons.Contains(lesson))
                    {
                        lessons.Add(lesson);
                        lessons.Add(lesson + "-Exercise");
                    }
                }
            }

            //Отпечатваме
            int inx = 1;
            foreach (var lesson in lessons)
            {
                Console.WriteLine($"{inx}.{lesson}");
                inx++;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Pianist
{
    class Pianist
    {
        public string Composer { get; set; }
        public string Key { get; set; }
        public Pianist(string composer, string key)
        {
            Composer = composer;
            Key = key;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var pianists = new Dictionary<string, Pianist>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split('|');
                string piece = data[0];
                string composer = data[1];
                string key = data[2];
                pianists.Add(piece, new Pianist(composer, key));
            }

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] dataPiece = input.Split('|');
                string operation = dataPiece[0];
                string namePiece = dataPiece[1];
                switch (operation)
                {
                    case "Add":

                        string composer = dataPiece[2];
                        string key = dataPiece[3];
                        if (pianists.ContainsKey(namePiece))
                        {
                            Console.WriteLine($"{namePiece} is already in the collection!");
                        }
                        else
                        {
                            pianists.Add(namePiece, new Pianist(composer, key));
                            Console.WriteLine($"{namePiece} by {composer} in {key} added to the collection!");
                        }
                        break;
                    case "Remove":
                        if (pianists.ContainsKey(namePiece))
                        {
                            Console.WriteLine($"Successfully removed {namePiece}!");
                            pianists.Remove(namePiece);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {namePiece} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        string newKey = dataPiece[2];
                        if (pianists.ContainsKey(namePiece))
                        {
                            pianists[namePiece].Key = newKey;
                            Console.WriteLine($"Changed the key of {namePiece} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {namePiece} does not exist in the collection.");
                        }
                        break;
                }
            }
            pianists = pianists.OrderBy(x => x.Key).ThenBy(x => x.Value.Composer).ToDictionary(x => x.Key, x => x.Value);
            foreach (var piece in pianists)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }
    }
}

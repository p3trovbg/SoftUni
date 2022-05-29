using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace _03._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSong = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();
            
            for (int i = 0; i < numSong; i++)
            {
                string[] data = Console.ReadLine().Split("_");
                string type = data[0];
                string name = data[1];
                string time = data[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;
                songs.Add(song);
            }
            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (var item in songs)
                {
                    Console.WriteLine(item.Name);
                }
                return;
            }
            List<Song> fillteredSongs = songs
                .Where(s => s.TypeList == typeList)
                .ToList();
            foreach (var item in fillteredSongs)
            {
                Console.WriteLine(item.Name);
            }


        }
    }
    class Song
     {
         public string TypeList { get; set; }
         public string Name { get; set; }
         public string Time { get; set; }


    }
}

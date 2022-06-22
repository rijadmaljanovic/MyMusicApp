using Newtonsoft.Json;
using MyMusicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Infrastructure.Database
{
    public static class DatabaseSeedHelper
    {
        private static string CurrentDirectory = Directory.GetCurrentDirectory();
        private static string JsonFilesLocation = Path.GetFullPath(Path.Combine(CurrentDirectory, @"..\\MyMusicApp.Infrastructure\\Database\\SongData\\"));

        public static List<Song> GetSongs()
        {
            dynamic array = ReadJSONFile("Songs.json");

            var songList = new List<Song>();

            for (int i = 0; i < array.Count; i++)
            {
                songList.Add(new Song
                {
                    SongName = array[i].title_en,
                    ArtistName = array[i].artist,
                    SongUrl= array[i].url_en,
                    IsFavourite = array[i].promo,
                    CategoryId= array[i].categories,
                    CreatedAt=DateTime.Today,
                    ModifiedAt= null
                });
            }

            return songList;
        }

        private static dynamic ReadJSONFile(string fileName)
        {
            string json = "";

            using (StreamReader r = new StreamReader(JsonFilesLocation + fileName))
            {
                json = r.ReadToEnd();
            }

            return JsonConvert.DeserializeObject(json);
        }
    }
}

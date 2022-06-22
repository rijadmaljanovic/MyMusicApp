using MyMusicApp.Core.Entities;
using MyMusicApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Infrastructure.Database
{
    public static class DatabaseInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();
            var Random = new Random();

            //check are there any users in the Db
            if (!context.Users.Any())
            {

                #region UserDataSeed

                var userList = new List<User>();

                for (int i = 1; i <= 5; i++)
                {
                    var salt = PasswordHashSaltGenerator.GenerateSalt();

                    var usernamePassword = "User" + i;

                    userList.Add(new User
                    {
                        Username = usernamePassword,
                        PasswordSalt = salt,
                        PasswordHash = PasswordHashSaltGenerator.HashPassword(salt, usernamePassword)
                    });
                }
                context.Users.AddRange(userList);
                context.SaveChanges();

                userList = userList.OrderBy(u => u.Id).ToList();
                var userIdMin = userList.First().Id;
                var userIdMax = userList.Last().Id;

                #endregion

                #region CategoryDataSeed

                var categoryList = new List<Category>();

                for (int i = 1; i <= 4 ; i++)
                {
                    if (i == 1)
                    {
                        categoryList.Add(new Category
                        {
                            CategoryName="Pop"
                        });
                    }
                    else if (i == 2)
                    {
                        categoryList.Add(new Category
                        {
                            CategoryName = "Rock"
                        });
                    }
                    else if (i == 3)
                    {
                        categoryList.Add(new Category
                        {
                            CategoryName = "Disco"
                        });
                    }
                    else if (i == 4)
                    {
                        categoryList.Add(new Category
                        {
                            CategoryName = "Rap"
                        });
                    }
                }

                context.Categories.AddRange(categoryList);
                context.SaveChanges();

                #endregion

                #region SongDataSeed

                var songList = DatabaseSeedHelper.GetSongs();
                context.Songs.AddRange(songList);
                context.SaveChanges();

                songList = songList.OrderBy(m => m.Id).ToList();
                var songIdMin = songList.First().Id;
                var songIdMax = songList.Last().Id;

                #endregion

                #region SongRatingDataSeed

                var movieRatingsList = new List<SongRating>();
                var allSongs = songList.Count;
                var allUsers = userList.Count;
                for (int i = 0; i < allSongs * 3; i++)
                {
                    var songRatingForAdd = new SongRating
                    {
                        SongId = Random.Next(songIdMin, songIdMax + 1),
                        UserId = Random.Next(userIdMin, userIdMax + 1),
                        Rating = Random.Next(1, 6)
                    };

                    if (movieRatingsList.Find(mr => mr.SongId == songRatingForAdd.SongId && mr.UserId == songRatingForAdd.UserId) == null)
                        movieRatingsList.Add(songRatingForAdd);
                }

                context.SongRatings.AddRange(movieRatingsList);
                context.SaveChanges();

                #endregion
            }
        }
    }
}

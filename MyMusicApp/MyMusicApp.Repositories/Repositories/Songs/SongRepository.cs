using MyMusicApp.Core.Entities;
using MyMusicApp.Core.Models;
using MyMusicApp.Infrastructure.Database;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMusicApp.Repositories.Repositories.Base;

namespace MyMusicApp.Repositories.Repositories.Songs
{
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        private readonly DatabaseContext _databaseContext;
        public SongRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<List<Song>> GetSongsAsync(SongRequestModel songRequestModel)
        {
            try
            {
                var itemsPerPage = 5;
                var list = await _databaseContext.Songs.Include(z => z.Ratings).Include(m=>m.Category).ToListAsync();

                return list
                .Where(m => Search(m, songRequestModel.Search))
                .Skip(itemsPerPage * (songRequestModel.Page - 1))
                .Take(5)
                .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> ", ex);
                return null;
            }
        }

        private bool Search(Song song, SearchModel searchModel)
        {
            if (searchModel == null)
            {
                return true;
            }
            else
            {
                searchModel.Value = searchModel.Value.ToLower();

                var x = song.SongName.ToLower().Contains(searchModel.Value) ||
                        song.ArtistName.ToLower().Contains(searchModel.Value);
                return x;
            }
        }

        public async Task<Song> GetSongById(int songId)
        {
            var movie = await _databaseContext.Songs.Include(r => r.Ratings).Include(x => x.Category).FirstOrDefaultAsync(m => m.Id == songId);

            return movie;
        }

        public async Task<Song> RateSongAsync(int songId, int userId, int rating)
        {
            if (!await _databaseContext.Songs.AnyAsync(m => m.Id == songId))
                return null;

            var songRating = await _databaseContext.SongRatings.FirstOrDefaultAsync(mr => mr.UserId == userId && mr.SongId == songId);

            if (songRating == null)
            {
                await _databaseContext.SongRatings.AddAsync(
                    new SongRating { UserId = userId, SongId = songId, Rating = rating });
            }
            else
            {
                songRating.Rating = rating;
            }

            await _databaseContext.SaveChangesAsync();

            return await _databaseContext.Songs
                .FirstOrDefaultAsync(m => m.Id == songId);
        }
    }
}

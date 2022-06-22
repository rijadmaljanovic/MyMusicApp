using MyMusicApp.Core.Entities;
using MyMusicApp.Core.Models;
using MyMusicApp.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Repositories.Repositories.Songs
{
    public interface ISongRepository : IBaseRepository<Song>
    {
        Task<List<Song>> GetSongsAsync(SongRequestModel songRequestModel);
        Task<Song> GetSongById(int songId);
        Task<Song> RateSongAsync(int songId, int userId, int rating);
    }
}

using MyMusicApp.Core.Entities;
using MyMusicApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Services.Services.Songs
{
    public interface ISongService
    {
        Task<List<SongModel>> GetSongsAsync(SongRequestModel movieRequestModel, int userId);
        Task<SongModel> RateSongAsync(int songId, int userId, int rating);
        Task<SongModel> AddSongAsync(SongModel model);
        Task<SongModel> UpdateSongAsync(int songId, SongModel model);
        Task<SongModel> GetSongById(int songId, int userId);
        Task<SongModel> DeleteSongAsync(int id);
    }
}

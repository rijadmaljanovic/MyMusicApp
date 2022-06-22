using AutoMapper;
using MyMusicApp.Core.Entities;
using MyMusicApp.Core.Models;
using MyMusicApp.Repositories.Repositories.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Services.Services.Songs
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public SongService(ISongRepository songRepository, IMapper mapper)
        {
            _songRepository = songRepository;
            _mapper = mapper;
        }

        #region GetSongs
        public async Task<List<SongModel>> GetSongsAsync(SongRequestModel movieRequestModel, int userId)
        {
            try
            {
                var songList = await _songRepository.GetSongsAsync(movieRequestModel);

                if (!songList.Any())
                    return null;

                var mappedSongList = _mapper.Map<List<SongModel>>(songList);

                // get user rate for song
                for (int i = 0; i < songList.Count; i++)
                {
                    mappedSongList[i].RatingByUser = songList[i].Ratings.FirstOrDefault(mr => mr.UserId == userId)?.Rating ?? 0;
                }

                return mappedSongList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> ", ex);
                return null;
            }
        }

        #endregion

        #region AddSong
        public async Task<SongModel> AddSongAsync(SongModel model)
        {
            try
            {
                var mappedAddedSong = _mapper.Map<Song>(model);

                mappedAddedSong.ModifiedAt = null;

                var addedSong = await _songRepository.Add(mappedAddedSong);

                if (addedSong == null)
                    return null;

                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> ", ex);
                return null;
            }
        }

        #endregion

        #region RateSong
        public async Task<SongModel> RateSongAsync(int songId, int userId, int rating)
        {
            try
            {
                var ratedSong = await _songRepository.RateSongAsync(songId, userId, rating);

                if (ratedSong == null)
                    return null;

                var mappedRatedSong = _mapper.Map<SongModel>(ratedSong);

                // get user rate for song
                mappedRatedSong.RatingByUser = ratedSong.Ratings.FirstOrDefault(mr => mr.UserId == userId)?.Rating ?? 0;

                Console.WriteLine("Song rating added.");

                return mappedRatedSong;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> ", ex);
                return null;
            }
        }

        #endregion

        #region GetSongById
        public async Task<SongModel> GetSongById(int songId, int userId)
        {
            try
            {
                var song = await _songRepository.GetSongById(songId);

                if (song == null)
                {
                    return null;
                }

                var mappedSong = _mapper.Map<SongModel>(song);

                // get user rate for song
                mappedSong.RatingByUser = song.Ratings.FirstOrDefault(mr => mr.UserId == userId)?.Rating ?? 0;

                return mappedSong;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> ", ex);
                return null;
            }
        }

        #endregion
        
        #region UpdateSong
        public async Task<SongModel> UpdateSongAsync(int songId, SongModel model)
        {
            try
            {
                var mappedSong = _mapper.Map<Song>(model);

                mappedSong.Id = songId;
                mappedSong.ModifiedAt = DateTime.Now;

                var updatedSong = await _songRepository.Update(mappedSong);

                if (updatedSong == null)
                    return null;

                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> ", ex);
                return null;
            }
        }

        #endregion

        #region DeleteSong
        public async Task<SongModel> DeleteSongAsync(int id)
        {
            try
            {
                var deletedSong = await _songRepository.Delete(id);

                var mappedSongModel= _mapper.Map<SongModel>(deletedSong);

                return mappedSongModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -> ", ex);
                return null;
            }
        }

        #endregion
    }
}

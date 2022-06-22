using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyMusicApp.Core.Helpers;
using MyMusicApp.Core.Models;
using MyMusicApp.Services.Services.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftrayTask.Backoffice.Controllers
{
    [Authorize]
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : Controller
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        #region GetSongs

        [HttpPost]
        public async Task<ActionResult<List<SongModel>>> GetSongs([FromBody] SongRequestModel songRequestModel)
        {
            try
            {
                var userId = JwtHelper.GetUserIdFromToken(HttpContext.User);

                var list = await _songService.GetSongsAsync(songRequestModel, userId);

                return Ok(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ->", ex);
                return StatusCode(500, "Something went wrong!");
            }
        }
        #endregion

        #region AddSong

        [HttpPost("add")]
        public async Task<ActionResult<SongModel>> AddSong([FromBody] SongModel songModel)
        {
            try
            {
                //var userId = JwtHelper.GetUserIdFromToken(HttpContext.User);

                var addedSong = await _songService.AddSongAsync(songModel);

                if (addedSong == null)
                    return BadRequest("Song is not added!");

                return Ok(addedSong);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ->", ex);
                return StatusCode(500, "Something went wrong!");
            }
        }

        #endregion

        #region RateSong
        [HttpPost("rate/{songId:int}")]
        public async Task<ActionResult<SongModel>> RateSongAsync([FromRoute] int songId, [FromBody] int rating)
        {
            try
            {
                var userId = JwtHelper.GetUserIdFromToken(HttpContext.User);

                var ratedSong = await _songService.RateSongAsync(songId, userId, rating);

                if (ratedSong == null)
                    return BadRequest("Song is not rated!");

                return Ok(ratedSong);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ->", ex);
                return StatusCode(500, "Something went wrong!");
            }
        }

        #endregion

        #region GetSongById

        [HttpGet("{songId:int}")]
        public async Task<ActionResult<SongModel>> GetSongById([FromRoute] int songId)
        {
            try
            {
                var userId = JwtHelper.GetUserIdFromToken(HttpContext.User);

                var song = await _songService.GetSongById(songId, userId);

                if (song == null)
                    return NotFound();

                return Ok(song);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ->", ex);
                return StatusCode(500, "Something went wrong!");
            }
        }

        #endregion

        #region UpdateSong

        [HttpPut("update/{songId:int}")]
        public async Task<ActionResult<SongModel>> UpdateSong([FromRoute] int songId, [FromBody] SongModel songModel)
        {
            try
            {
                //var userId = JwtHelper.GetUserIdFromToken(HttpContext.User);

                var list = await _songService.UpdateSongAsync(songId, songModel);

                return Ok(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ->", ex);
                return StatusCode(500, "Something went wrong!");
            }
        }

        #endregion

        #region DeleteSong

        [HttpDelete]
        public async Task<ActionResult<SongModel>> DeleteSong(int id)
        {
            try
            {
                //var userId = JwtHelper.GetUserIdFromToken(HttpContext.User);

                var deletedSong = await _songService.DeleteSongAsync(id);

                return Ok(deletedSong);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ->", ex);
                return StatusCode(500, "Something went wrong!");
            }
        }

        #endregion
    }
}

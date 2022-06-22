using MyMusicApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Services.Services.Users
{
    public interface IUserService
    {
        Task<string> LoginAndGenerateJWTAsync(LoginModel model);
    }
}

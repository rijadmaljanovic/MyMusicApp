using MyMusicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicApp.Repositories.Repositories.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersByUsernameAsync(string username);
    }
}

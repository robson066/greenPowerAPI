using greenPower.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace greenPower.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDTO> Get(string email);
        Task<IEnumerable<UserDTO>> Browse();
        Task Register(Guid userID, string username, string email,
            string password, string role);
        Task Login(string email, string password);
    }
}

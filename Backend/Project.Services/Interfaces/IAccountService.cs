using Project.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services.Interfaces
{
    public interface IAccountService
    {
        Task<User> AuthenticateUser(string email, string password);

        Task<bool> Register(User user);

        Task<bool> IsAdmin(string email);

        Task<bool> UserAlreadyExist(string email);

        Task<bool> RevokeSubscription(Guid Id);

        Task<IEnumerable<User> > getUsersList();
    }
}

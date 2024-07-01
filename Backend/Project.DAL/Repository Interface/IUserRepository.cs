
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repository_Interface
{
    public interface IUserRepository
    {
        Task<bool> IsAdmin( string EmailId);
        Task ChangeSubscriptionStatus(Guid UserId);  
        Task<bool> UserAlreadyExist(string EmailId);
        Task<User> AutenticateUser(string email, string password);

        void RegisterUser(User user);

        Task<IEnumerable<User>> GetAllUser(); 

    }
}

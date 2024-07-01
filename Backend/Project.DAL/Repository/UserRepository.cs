using Microsoft.EntityFrameworkCore;
using Project.DAL.Database;
using Project.DAL.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        private bool MatchPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var paramPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != paramPasswordHash[i]) return false;
                }
                return true;
            }
        }

        public async void RegisterUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> UserAlreadyExist(string EmailId)
        {
            return await _context.Users.AnyAsync(x => x.EmailId == EmailId);
        }

        public async Task<bool> IsAdmin(string EmailId)
        {
            return await _context.Users.AnyAsync(x => ((x.EmailId == EmailId) && x.IsAdmin));
        }


        public async Task ChangeSubscriptionStatus(Guid UserId)
        {
            var user = await _context.Users.FindAsync(UserId);
            user.SubscriptionStatus = !user.SubscriptionStatus; 
             _context.Users.Update(user);
        }
        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> AutenticateUser(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.EmailId == email);

            if (user == null) return null;

            if (!MatchPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;
            return user;
        }
    }
}

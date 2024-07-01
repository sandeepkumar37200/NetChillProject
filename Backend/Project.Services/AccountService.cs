using Project.DAL;
using Project.DAL.Repository;
using Project.DAL.UOW;
using Project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Services
{
    public class AccountService: IAccountService
    {
        public IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> AuthenticateUser(string email, string password) 
        {
            return await _unitOfWork.userRepository.AutenticateUser(email, password);
        }

        public async Task<IEnumerable<User>> getUsersList()
        {
            return await _unitOfWork.userRepository.GetAllUser();
        }

        public async Task<bool> IsAdmin(string email)
        {
            return await _unitOfWork.userRepository.IsAdmin(email);
        }

        public async Task<bool> Register(User user)
        {
             _unitOfWork.userRepository.RegisterUser(user);
             return await _unitOfWork.SaveAsync();
        }

        public async Task<bool> RevokeSubscription(Guid Id)
        {
            await _unitOfWork.userRepository.ChangeSubscriptionStatus(Id);
                return await _unitOfWork.SaveAsync();
        }

        public async Task<bool> UserAlreadyExist(string email)
        {
            return await _unitOfWork.userRepository.UserAlreadyExist(email);
        }
    }
}

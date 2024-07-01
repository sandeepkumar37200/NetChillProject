using Project.DAL.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.UOW
{
    public interface IUnitOfWork
    {
         IMovieRepository movieRepository { get;}
         IUserRepository userRepository { get;}

        Task<bool> SaveAsync();
    }
}

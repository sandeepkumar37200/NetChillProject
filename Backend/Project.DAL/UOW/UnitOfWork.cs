using Project.DAL.Database;
using Project.DAL.Repository;
using Project.DAL.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            movieRepository = new MovieRepository(context);
            userRepository = new UserRepository(context);
        }

        public IMovieRepository movieRepository { get; private set; }

        public IUserRepository userRepository { get; private set; }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}

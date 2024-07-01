using Project.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Services.Interfaces
{
    public interface ITokenService
    {
        string BuildToken(string Jwtkey, string issuer, User user);
    }
}

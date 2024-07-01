using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Dtos
{
    public class LoginReqDto
    {
        public string EmailId { get; set; }

        public string  Password { get; set; }
    }
}

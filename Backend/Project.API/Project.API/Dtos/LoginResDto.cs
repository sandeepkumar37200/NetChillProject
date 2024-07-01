using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Dtos
{
    public class LoginResDto
    {
        public string  EmailId { get; set; }
        public string Token { get; set; }
        public Guid UserId { get; set; }
        public bool IsAdmin {get; set;}
    }
}

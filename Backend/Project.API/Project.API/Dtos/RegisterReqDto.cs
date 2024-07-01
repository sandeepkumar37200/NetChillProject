using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.API.Dtos
{
    public class RegisterReqDto
    {
        public string EmailId { get; set; }
        public string UnHashedPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; }

    }
}

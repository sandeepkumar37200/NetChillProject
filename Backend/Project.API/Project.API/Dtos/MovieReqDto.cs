using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Project.API.Dtos
{
    public class MovieReqDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseYear { get; set; }
        public DateTime AvailabilityDate {get; set;}
        public bool IsFeatured { get; set; }
        public string MoviesPosterFile { get; set; }
        public string ContentPathFile { get; set; }
    }
}

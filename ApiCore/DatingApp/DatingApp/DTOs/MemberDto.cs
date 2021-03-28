using DatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
     
        public string KnownAs { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<BlogDetailDto> BlogDetails { get; set; }
       // public ICollection<BlogDetailDto> PostDetails { get; set; }

    }
}

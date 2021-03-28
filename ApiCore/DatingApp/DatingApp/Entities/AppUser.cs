using DatingApp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Entities
{
    public class AppUser
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "char(50)")]
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [Column(TypeName = "char(50)")]
        public string KnownAs { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        [Column(TypeName = "char(50)")]
        public string City { get; set; }
        [Column(TypeName = "char(50)")]
        public string Country { get; set; }
        public ICollection<BlogDetail> BlogDetails { get; set; }
       
    }

    
}

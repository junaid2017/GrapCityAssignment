using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Entities
{
    [Table("BlogsDetails")]
    public class BlogDetail
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "char(200)")]
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public string BackGround { get; set; }
        public bool DeletedPost { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }


    }
}

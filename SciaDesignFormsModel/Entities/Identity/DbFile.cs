using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using SciaDesignFormsModel.Shared;

namespace SciaDesignFormsModel.Entities.Identity
{
    public class DbFile
    {
        //[Key]
        public int ID { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        [Required]
        [ForeignKey("ApplicationUserID")]
        public string ApplicationUserID { get; set; }
        public virtual IdentityUser ApplicationUser { get; set; }
    }
}

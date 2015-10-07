using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using SciaDesignFormsModel.Shared;

namespace SciaDesignFormsModel.Entities.Identity.DbFiles
{
    public class DbFile
    {
        public int ID { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public string Description { get; set; }
        [Required]
        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        public virtual IdentityUser ApplicationUser { get; set; }
    }
}

using System;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SciaDesignFormsModel.Entities.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
            : base()
        {
        }
        public ApplicationRole(string name)
            : base(name)
        {
        }
        public string Description { get; set; }
    }
}

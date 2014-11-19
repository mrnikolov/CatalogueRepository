using Microsoft.AspNet.Identity.EntityFramework;
using Catalogue.Models.Entities;

namespace Catalogue.Models
{
    public class ApplicationDbContext : IdentityDbContext<Users>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }
    }
}

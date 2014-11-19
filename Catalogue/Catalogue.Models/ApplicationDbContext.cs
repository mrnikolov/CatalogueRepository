using Microsoft.AspNet.Identity.EntityFramework;
using Catalogue.Models.Entities;

namespace Catalogue.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }
    }
}

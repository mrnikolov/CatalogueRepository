namespace Catalogue.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class User : IdentityUser
    {
        public User()
        {
            Wishlists = new HashSet<Wishlist>();
        }

        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        public short Gender { get; set; }

        public virtual ICollection<Wishlist> Wishlists { get; set; }

    }
}

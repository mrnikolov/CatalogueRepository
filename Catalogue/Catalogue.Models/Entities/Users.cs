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
            Comments = new HashSet<Comment>();
            LikesDislikes = new HashSet<LikeDislike>();
            Ratings = new HashSet<Rating>();
            UserClaim = new HashSet<UserClaim>();
            UserLogin = new HashSet<UserLogin>();
            Wishlists = new HashSet<Wishlist>();
            UserRole = new HashSet<UserRole>();
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

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<LikeDislike> LikesDislikes { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<UserClaim> UserClaim { get; set; }

        public virtual ICollection<UserLogin> UserLogin { get; set; }

        public virtual ICollection<Wishlist> Wishlists { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}

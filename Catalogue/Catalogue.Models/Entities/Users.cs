namespace Catalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            LikesDislikes = new HashSet<LikesDislikes>();
            Ratings = new HashSet<Ratings>();
            UserClaim = new HashSet<UserClaim>();
            UserLogin = new HashSet<UserLogin>();
            Wishlists = new HashSet<Wishlists>();
            UserRole = new HashSet<UserRole>();
        }

        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        [StringLength(100)]
        public string SecurityStamp { get; set; }

        [StringLength(25)]
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }

        public short Gender { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int WishlistID { get; set; }

        public int AccessFailedCount { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }

        public virtual ICollection<LikesDislikes> LikesDislikes { get; set; }

        public virtual ICollection<Ratings> Ratings { get; set; }

        public virtual ICollection<UserClaim> UserClaim { get; set; }

        public virtual ICollection<UserLogin> UserLogin { get; set; }

        public virtual ICollection<Wishlists> Wishlists { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}

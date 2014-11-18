namespace Catalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserClaim")]
    public partial class UserClaim
    {
        public int UserID { get; set; }

        [Key]
        public int ClaimID { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public virtual Users Users { get; set; }
    }
}

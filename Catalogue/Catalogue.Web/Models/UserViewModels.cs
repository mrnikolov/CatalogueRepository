using Catalogue.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Catalogue.Web.Models
{
    public class UserViewModels
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public Gender? Gender { get; set; }

        public bool isAdmin { get; set; }

        public bool isManager { get; set; }

        public bool isModerator { get; set; }
    }
}
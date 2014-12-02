using Catalogue.Models.Entities;
using Catalogue.Models.Infrastructure;
using Catalogue.Models.Services.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Catalogue.Models.Services.Contracts
{
    public interface IAdminService
    {
        void Modify(User user);

        void ModifyUserRoles(User user, UserRole userRole);

        void Remove(User user);

        void DeleteUserRoles(User user);

        void AddUserRole(IdentityUserRole userRole);

        bool IsInRole(string userId, string role);

        User Find(string id);

        PagedList<User> GetUsers(int? page);

        IEnumerable<User> GetAll();

        UserRole GetUserRoles(User user);
    }
}

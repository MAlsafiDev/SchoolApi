using SchoolProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Abstract
{
    public interface IAuthorizationService
    {
        public Task<RoleResult> AddRoleAsync(string roleName);
        public Task<bool> IsRoleExistByName(string roleName);
        Task<RoleResult> EditRoleAsync(Domain.Request.EditRoleRequest request);
        public Task<RoleResult> DeleteRoleAsync(string roleId);
        Task<RoleResult> AssignRoleToUserAsync(string userId, string roleName);
        Task<RoleResult> RemoveRoleFromUserAsync(string userId, string roleName);
        Task<RoleResult> UpdateUserRolesAsync(string userId, List<string> roles);

    }
}

using Microsoft.AspNetCore.Identity;
using SchoolProject.Domain.Enum;
using SchoolProject.Domain.Request;
using SchoolProject.Infrastructure.Identity;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Services.Implementaion
{
    public class AuthorizationService : IAuthorizationService
    {
       
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
       
        public AuthorizationService(RoleManager<IdentityRole> roleManager,UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }



        public async Task<RoleResult> AddRoleAsync(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
                return RoleResult.AlreadyExist;

            var role = new IdentityRole(roleName);
            var result = await _roleManager.CreateAsync(role);

            return result.Succeeded ? RoleResult.Success : RoleResult.Failed;
        }


        public async Task<bool> IsRoleExistByName(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<RoleResult> EditRoleAsync(EditRoleRequest request)
        {
            var role = await _roleManager.FindByIdAsync(request.Id);
            if (role == null)
                return RoleResult.NotFound;

            if (role.Name == request.Name)
                return RoleResult.Success;

            if (await _roleManager.RoleExistsAsync(request.Name))
                return RoleResult.AlreadyExist;

            role.Name = request.Name;
            var result = await _roleManager.UpdateAsync(role);

            return result.Succeeded ? RoleResult.Success : RoleResult.Failed;
        }


        public async Task<RoleResult> DeleteRoleAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
                return RoleResult.NotFound;

            var users = await _userManager.GetUsersInRoleAsync(role.Name!);
            if (users.Any())
                return RoleResult.Used;

            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded ? RoleResult.Success : RoleResult.Failed;
        }

        public async Task<RoleResult> AssignRoleToUserAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return RoleResult.NotFound;

            if (!await _roleManager.RoleExistsAsync(roleName))
                return RoleResult.NotFound;

            if (await _userManager.IsInRoleAsync(user, roleName))
                return RoleResult.AlreadyExist;

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded ? RoleResult.Success : RoleResult.Failed;
        }

        public async Task<RoleResult> RemoveRoleFromUserAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return RoleResult.NotFound;

            if (!await _userManager.IsInRoleAsync(user, roleName))
                return RoleResult.NotFound;

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            return result.Succeeded ? RoleResult.Success : RoleResult.Failed;
        }

        public async Task<RoleResult> UpdateUserRolesAsync(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return RoleResult.NotFound;

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                    return RoleResult.NotFound;
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!removeResult.Succeeded)
                return RoleResult.Failed;

            var addResult = await _userManager.AddToRolesAsync(user, roles);

            return addResult.Succeeded ? RoleResult.Success : RoleResult.Failed;
        }


    }
}
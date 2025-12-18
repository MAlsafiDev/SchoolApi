using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Authorization.Queries.Dtos;
using SchoolProject.Application.Features.Authorization.Queries.Model;
using SchoolProject.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authorization.Queries.Handler
{
    public class GetUserRolesQueryHandler: IRequestHandler<GetUserRolesQuery, Response<UserRoleDto>>
    {
        private readonly UserManager<User> _userManager;

        public GetUserRolesQueryHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<UserRoleDto>> Handle(GetUserRolesQuery request,CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                return Response<UserRoleDto>.NotFound();

            var roles = await _userManager.GetRolesAsync(user);

            return Response<UserRoleDto>.Success(new UserRoleDto
            {
                UserId = user.Id,
                Roles = roles.ToList()
            });
        }
    }

}

using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Authorization.Queries.Dtos;
using SchoolProject.Application.Features.Authorization.Queries.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authorization.Queries.Handler
{
    public class GetRoleByIdQueryHandler: IRequestHandler<GetRoleByIdQuery, Response<RoleDto>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetRoleByIdQueryHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Response<RoleDto>> Handle(GetRoleByIdQuery request,CancellationToken cancellationToken)
        {
            var role = await _roleManager.FindByIdAsync(request.Id);
            if (role == null)
                return Response<RoleDto>.NotFound();

            return Response<RoleDto>.Success(new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            });
        }
    }

}

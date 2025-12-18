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
    public class GetRolesQueryHandler: IRequestHandler<GetRolesQuery, Response<List<RoleDto>>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetRolesQueryHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<Response<List<RoleDto>>> Handle(GetRolesQuery request,CancellationToken cancellationToken)
        {
            var roles = _roleManager.Roles
                .Select(r => new RoleDto
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .ToList();

            return Response<List<RoleDto>>.Success(roles);
        }
    }

}

using MediatR;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Authorization.Command.Model;
using SchoolProject.Domain.Enum;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authorization.Command.Handler
{
    public class AddRoleCommandHandler: IRequestHandler<AddRoleCommand, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;

        public AddRoleCommandHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.AddRoleAsync(request.RoleName);

            return result switch
            {
                RoleResult.Success =>
                    Response<string>.Success("Role created successfully"),

                RoleResult.AlreadyExist =>
                    Response<string>.Fail("Role already exists"),

                _ =>
                    Response<string>.Fail("Failed to create role")
            };
        }
    }

}

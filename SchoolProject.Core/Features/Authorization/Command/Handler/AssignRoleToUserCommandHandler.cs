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
    public class AssignRoleToUserCommandHandler
    : IRequestHandler<AssignRoleToUserCommand, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;

        public AssignRoleToUserCommandHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(AssignRoleToUserCommand request,CancellationToken cancellationToken)
        {
            var result = await _authorizationService.AssignRoleToUserAsync(request.UserId, request.RoleName);

            return result switch
            {
                RoleResult.Success =>
                    Response<string>.Success("Role assigned successfully"),

                RoleResult.AlreadyExist =>
                    Response<string>.Fail("User already has this role"),

                RoleResult.NotFound =>
                    Response<string>.NotFound(),

                _ =>
                    Response<string>.Fail("Assign role failed")
            };
        }
    }

}

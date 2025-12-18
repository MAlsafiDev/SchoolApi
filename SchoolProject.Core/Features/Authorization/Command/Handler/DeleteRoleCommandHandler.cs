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
    public class DeleteRoleCommandHandler: IRequestHandler<DeleteRoleCommand, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;

        public DeleteRoleCommandHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.DeleteRoleAsync(request.Id);

            return result switch
            {
                RoleResult.Success =>
                    Response<string>.Success("Role deleted successfully"),

                RoleResult.Used =>
                    Response<string>.Fail("Role is assigned to users"),

                RoleResult.NotFound =>
                    Response<string>.Fail("Role not found"),

                _ =>
                    Response<string>.Fail("Failed to delete role")
            };
        }
    }

}

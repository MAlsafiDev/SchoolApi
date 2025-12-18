using MediatR;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Authorization.Command.Model;
using SchoolProject.Domain.Enum;
using SchoolProject.Domain.Request;
using SchoolProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authorization.Command.Handler
{
    public class EditRoleCommandHandler: IRequestHandler<EditRoleCommand, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;

        public EditRoleCommandHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.EditRoleAsync(
                new EditRoleRequest
                {
                    Id = request.Id,
                    Name = request.Name
                });

            return result switch
            {
                RoleResult.Success =>
                    Response<string>.Success("Role updated successfully"),

                RoleResult.NotFound =>
                    Response<string>.Fail("Role not found"),

                RoleResult.AlreadyExist =>
                    Response<string>.Fail("Role name already exists"),

                _ =>
                    Response<string>.Fail("Failed to update role")
            };
        }
    }

}

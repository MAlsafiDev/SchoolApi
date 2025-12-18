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
    public class UpdateUserRolesCommandHandler: IRequestHandler<UpdateUserRolesCommand, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;

        public UpdateUserRolesCommandHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(UpdateUserRolesCommand request,CancellationToken cancellationToken)
        {
            var result = await _authorizationService
                .UpdateUserRolesAsync(request.UserId, request.Roles);

            return result switch
            {
                RoleResult.Success =>
                    Response<string>.Success("User roles updated successfully"),

                RoleResult.NotFound =>
                    Response<string>.NotFound(),

                _ =>
                    Response<string>.Fail("Update user roles failed")
            };
        }
    }

}

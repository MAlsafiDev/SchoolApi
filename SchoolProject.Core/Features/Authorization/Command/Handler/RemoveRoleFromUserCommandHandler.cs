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
    public class RemoveRoleFromUserCommandHandler: IRequestHandler<RemoveRoleFromUserCommand, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;

        public RemoveRoleFromUserCommandHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<Response<string>> Handle(
            RemoveRoleFromUserCommand request,
            CancellationToken cancellationToken)
        {
            var result = await _authorizationService
                .RemoveRoleFromUserAsync(request.UserId, request.RoleName);

            return result switch
            {
                RoleResult.Success =>
                    Response<string>.Success("Role removed from user"),

                RoleResult.NotFound =>
                    Response<string>.NotFound(),

                _ =>
                    Response<string>.Fail("Remove role failed")
            };
        }
    }

}

using MediatR;
using SchoolProject.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authorization.Command.Model
{
    public class RemoveRoleFromUserCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }

}

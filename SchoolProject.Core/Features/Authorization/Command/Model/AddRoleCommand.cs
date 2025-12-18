using MediatR;
using SchoolProject.Application.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authorization.Command.Model
{
    public class AddRoleCommand: IRequest<Response<string>>
    {
        public string RoleName { get; set; } = string.Empty;
     

    }
}

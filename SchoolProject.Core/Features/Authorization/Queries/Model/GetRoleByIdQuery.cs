using MediatR;
using SchoolProject.Application.Bases;
using SchoolProject.Application.Features.Authorization.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authorization.Queries.Model
{
    public class GetRoleByIdQuery : IRequest<Response<RoleDto>>
    {
        public string Id { get; set; }
    }

}

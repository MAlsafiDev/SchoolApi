using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authorization.Queries.Dtos
{
    public class UserRoleDto
    {
        public string UserId { get; set; }
        public List<string> Roles { get; set; } = new();
    }

}

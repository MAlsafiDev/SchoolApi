using FluentValidation;
using SchoolProject.Application.Features.Authorization.Command.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authorization.Command.Validator
{
    public class RemoveRoleFromUserValidator: AbstractValidator<RemoveRoleFromUserCommand>
    {
        public RemoveRoleFromUserValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.RoleName).NotEmpty();
        }
    }

}

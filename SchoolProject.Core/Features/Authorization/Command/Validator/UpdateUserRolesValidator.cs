using FluentValidation;
using SchoolProject.Application.Features.Authorization.Command.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authorization.Command.Validator
{
    public class UpdateUserRolesValidator: AbstractValidator<UpdateUserRolesCommand>
    {
        public UpdateUserRolesValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.Roles)
                .NotNull()
                .Must(r => r.Any())
                .WithMessage("At least one role is required");
        }
    }

}

using FluentValidation;
using SchoolProject.Application.Features.Authorization.Command.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authorization.Command.Validator
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Role Id is required");
        }
    }

}

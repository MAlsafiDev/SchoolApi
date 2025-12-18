using FluentValidation;
using SchoolProject.Application.Features.Authorization.Command.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Application.Features.Authorization.Command.Validator
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        public EditRoleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Role Id is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Role name is required")
                .MaximumLength(50);
        }
    }

}

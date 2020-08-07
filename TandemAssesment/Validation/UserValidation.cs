using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TandemAssesment.Model;

namespace TandemAssesment.Validation
{
    public class UserValidation : AbstractValidator<UserSaveModel>
    {
        public UserValidation()
        {
            RuleFor(s => s.EmailAddress).NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");
            RuleFor(reg => reg.FirstName).NotEmpty().WithMessage("First Name Required");
            RuleFor(reg => reg.LastName).NotEmpty().WithMessage("Last Name Required");

        }
    }
}

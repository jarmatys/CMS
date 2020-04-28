using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TPay.Models.Transaction.Requests;

namespace TPay.Models.Validators
{
    public class CreateValidator : AbstractValidator<Create>
    {
        public CreateValidator()
        {
            RuleFor(v => v.Id).NotEmpty().WithMessage("'{PropertyName}' can not be empty.");
        }
    }
}

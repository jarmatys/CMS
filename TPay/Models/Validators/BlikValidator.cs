using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TPay.Models.Transaction.Requests;

namespace TPay.Models.Validators
{
    public class BlikValidator : AbstractValidator<Blik>
    {
        public BlikValidator()
        {
            RuleFor(v => v.ApiPassword).NotEmpty().WithMessage("{PropertyName} can not be empty.");
            RuleFor(v => v.Title).NotEmpty().WithMessage("{PropertyName} can not be empty.");
            RuleFor(v => v.Code).Must(BeEmptyOr6Digits).WithMessage("{PropertyName} shold be empty if registered alias was provided. Otherwise code should have 6 digits.");
        }

        internal bool BeEmptyOr6Digits(int? code)
        {
            if (code == null)
            {
                return true;
            }
            else if (code.ToString().Length == 6)
            {
                return true;
            }

            return false;
        }
    }
}

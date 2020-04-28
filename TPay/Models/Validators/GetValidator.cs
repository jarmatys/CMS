using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TPay.Models.Transaction.Requests;

namespace TPay.Models.Validators
{
    public class GetValidator : AbstractValidator<Get>
    {
        public GetValidator()
        {
            RuleFor(v => v.Title).NotEmpty().WithMessage("{PropertyName} can not be empty.");
            RuleFor(v => v.ApiPassword).NotEmpty().WithMessage("{PropertyName} can not be empty.");
        }
    }
}

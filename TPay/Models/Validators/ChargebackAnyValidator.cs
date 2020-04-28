using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TPay.Models.Transaction.Requests;

namespace TPay.Models.Validators
{
    public class ChargebackAnyValidator : AbstractValidator<ChargebackAny>
    {
        private float _transactionAmount;
        public ChargebackAnyValidator(float amount)
        {
            _transactionAmount = amount;

            RuleFor(v => v.ApiPassword).NotEmpty().WithMessage("{PropertyName} can not be empty.");
            RuleFor(v => v.Title).NotEmpty().WithMessage("{PropertyName} can not be empty.");
            RuleFor(v => v.ChargebackAmount)
                .NotEmpty().WithMessage("{PropertyName} can not be empty.")
                .Must(BeSmallerThanTransactionValue).WithMessage("{PropertyName} must be smaller than transaction value");

        }
        private bool BeSmallerThanTransactionValue(string amount)
        {
            if (float.Parse(amount) <= _transactionAmount)
            {
                return true;
            }

            return false;
        }
    }
}

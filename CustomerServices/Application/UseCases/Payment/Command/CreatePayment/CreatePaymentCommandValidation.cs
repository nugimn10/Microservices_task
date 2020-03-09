using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using CustomerServices.Domain.Models;

namespace CustomerServices.Application.UseCases.Payment.Command.CreatePayment
{
    public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
    {
        public CreatePaymentCommandValidator()
        {
            RuleFor(x => x.DataD.Attributes.name_no_card).NotEmpty().WithMessage("Username Cant Be Empty");
            RuleFor(x => x.DataD.Attributes.name_no_card).MaximumLength(20).WithMessage("Max username length");
            RuleFor(x => x.DataD.Attributes.exp_month).NotEmpty().WithMessage("exp moth Cant Be Empty");
            RuleFor(x => Convert.ToInt32(x.DataD.Attributes.exp_month)).InclusiveBetween(1,12).WithMessage("exp_month is bettween 1-12");
            RuleFor(x => x.DataD.Attributes.exp_year).NotEmpty().WithMessage("exp year Cant Be Empty");
            RuleFor(x => x.DataD.Attributes.credit_card_number).CreditCard().WithMessage("credit card number must be type of credit card number");
        }
    }

}
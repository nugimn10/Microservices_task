using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using MerchantServices.Domain.Models;

namespace MerchantServices.Application.UseCases.Merchant.Command.CreateMerchant
{
    public class CreateMerchantCommandValidator : AbstractValidator<CreateMerchantCommand>
    {
        public CreateMerchantCommandValidator()
        {
            RuleFor(x => x.DataD.Attributes.name).NotEmpty().WithMessage("name Cant Be Empty");
            RuleFor(x => x.DataD.Attributes.address).NotEmpty().WithMessage("address Cant Be Empty");
            RuleFor(x => x.DataD.Attributes.rating).InclusiveBetween(1,5).WithMessage("price Cant Be Empty");
        }
    }

}
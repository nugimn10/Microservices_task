using System;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using ProductServices.Domain.Models;

namespace ProductServices.Application.UseCases.Product.Command.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.DataD.Attributes.name).NotEmpty().WithMessage("name Cant Be Empty");
            RuleFor(x => x.DataD.Attributes.name).MaximumLength(50).WithMessage("Max username length 50");
            RuleFor(x => x.DataD.Attributes.price).NotEmpty().WithMessage("price Cant Be Empty");
            RuleFor(x => x.DataD.Attributes.price).GreaterThanOrEqualTo(1000).WithMessage("price must be greater than 1000");

        }
    }

}
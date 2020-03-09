using MediatR;
using System;
using ProductServices.Domain.Models;
using ProductServices.Application.Models.Query;

namespace ProductServices.Application.UseCases.Product.Command.CreateProduct
{
    public class CreateProductCommand : RequestData<ProductD>,IRequest<CreateProductCommandDto>
    {

    }



}
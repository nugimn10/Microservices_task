using ProductServices.Domain.Models;
using System;
using ProductServices.Application.Models.Query;
using MediatR;

namespace ProductServices.Application.UseCases.Product.Command.PutProduct
{
    public class PutProductCommand : RequestData<ProductD>, IRequest<PutProductCommandDto>
    {

    }

}
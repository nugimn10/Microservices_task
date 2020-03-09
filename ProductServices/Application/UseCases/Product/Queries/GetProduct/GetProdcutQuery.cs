using System;
using MediatR;

namespace ProductServices.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProductQuery : IRequest<GetProductDto>
    {
        public int Id { get; set; }

        public GetProductQuery(int id)
        {
            Id = id;
        }
    }
}
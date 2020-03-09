using System.Threading;
using System.Threading.Tasks;
using ProductServices.Infrastructure.Presistence;
using ProductServices.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ProductServices.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProdcutQueryHandler : IRequestHandler<GetProductQuery, GetProductDto>
    {
        private readonly dbContext _context;

        public GetProdcutQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Product.FirstOrDefaultAsync(e => e.id == request.Id);

            return new GetProductDto
            {
                Success = true,
                Message = "Creator successfully retrieved",
                Data = new ProductD
                {
                    name = result.name,
                    price = result.price,
                }
            };

        }
    }
}
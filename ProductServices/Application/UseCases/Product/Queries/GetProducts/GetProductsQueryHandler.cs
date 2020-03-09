using System.Threading;
using System.Threading.Tasks;
using ProductServices.Infrastructure.Presistence;
using ProductServices.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Linq;

namespace ProductServices.Application.UseCases.Product.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsDto>
    {
        private readonly dbContext _context;

        public GetProductsQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetProductsDto> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {

            var data = await _context.Product.ToListAsync();

            return new GetProductsDto
            {
                Success = true,
                Message = "Creator successfully retrieved",
                Data = data
            };

        }
    }
}
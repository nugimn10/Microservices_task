using System.Threading;
using System.Threading.Tasks;
using MerchantServices.Infrastructure.Presistences;
using MerchantServices.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Linq;

namespace MerchantServices.Application.UseCases.Merchant.Queries.GetMerchants
{
    public class GetMerchantsQueryHandler : IRequestHandler<GetMerchantsQuery, GetMerchantsDto>
    {
        private readonly dbContext _context;

        public GetMerchantsQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetMerchantsDto> Handle(GetMerchantsQuery request, CancellationToken cancellationToken)
        {

            var data = await _context.Merchant.ToListAsync();

            var result = data.Select(e => new MerchantD
            {
                name = e.name,
                address = e.address,
            });

            return new GetMerchantsDto
            {
                Success = true,
                Message = "Creator successfully retrieved",
                Data = result.ToList()
            };

        }
    }
}
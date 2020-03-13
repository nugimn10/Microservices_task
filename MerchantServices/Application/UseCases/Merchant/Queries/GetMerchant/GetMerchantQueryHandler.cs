using System.Threading;
using System.Threading.Tasks;
using MerchantServices.Infrastructure.Presistences;
using MerchantServices.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace MerchantServices.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantQueryHandler : IRequestHandler<GetMerchantQuery, GetMerchantDto>
    {
        private readonly dbContext _context;

        public GetMerchantQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetMerchantDto> Handle(GetMerchantQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Merchant.FirstOrDefaultAsync(e => e.id == request.Id);

            return new GetMerchantDto
            {
                Success = true,
                Message = "Merchant successfully retrieved",
                Data = new MerchantD
                {
                    name = result.name,
                    address = result.address,
                }
            };

        }
    }
}
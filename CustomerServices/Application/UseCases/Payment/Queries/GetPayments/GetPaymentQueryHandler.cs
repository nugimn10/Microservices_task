using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Infrastructure.Presistences;
using CustomerServices.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Linq;

namespace CustomerServices.Application.UseCases.Payment.Queries.GetPayments
{
    public class GetPaymentsQueryHandler : IRequestHandler<GetPaymentsQuery, GetPaymentsDto>
    {
        private readonly dbContext _context;

        public GetPaymentsQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetPaymentsDto> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
        {

           
            var data = await _context.Customer_Payment_Cards.ToListAsync();

            return new GetPaymentsDto
            {
                Success = true,
                Message = "Creator successfully retrieved",
                Data = data
            };

        }
    }
}
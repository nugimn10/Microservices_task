using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Infrastructure.Presistences;
using CustomerServices.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CustomerServices.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, GetPaymentDto>
    {
        private readonly dbContext _context;

        public GetPaymentQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetPaymentDto> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Customer_Payment_Cards.FirstOrDefaultAsync(e => e.id == request.Id);

            return new GetPaymentDto
            {
                Success = true,
                Message = "Creator successfully retrieved",
                Data = new Customer_Payment_Card
                {
                    customer_id = result.customer_id,
                    credit_card_number = result.credit_card_number,
                }
            };

        }
    }
}
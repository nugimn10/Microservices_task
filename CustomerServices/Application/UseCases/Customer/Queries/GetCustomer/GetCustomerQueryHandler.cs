using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Infrastructure.Presistences;
using CustomerServices.Domain.Models;

using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CustomerServices.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerDto>
    {
        private readonly dbContext _context;

        public GetCustomerQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetCustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {

            var result = await _context.Customer.FirstOrDefaultAsync(e => e.id == request.Id);

            return new GetCustomerDto
            {
                Success = true,
                Message = "Customerw successfully retrieved",
                Data = new CustomerD
                {
                    fullname = result.fullname,
                    username = result.username,
                }
            };

        }
    }
}
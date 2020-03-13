using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Infrastructure.Presistences;
using CustomerServices.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Linq;

namespace CustomerServices.Application.UseCases.Customer.Queries.GetCustomers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersDto>
    {
        private readonly dbContext _context;

        public GetCustomerQueryHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<GetCustomersDto> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {

            var data = await _context.Customer.ToListAsync();

            return new GetCustomersDto
            {
                Success = true,
                Message = "customer successfully retrieved",
                Data = data
            };

        }
    }
}
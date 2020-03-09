using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Infrastructure.Presistences;
using CustomerServices.Application.Interfaces;
using CustomerServices.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CustomerServices.Application.UseCases.Customer.Command.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandDto>
    {
        private readonly dbContext _context;

        public DeleteCustomerCommandHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<DeleteCustomerCommandDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var delete = await _context.Customer.FindAsync(request.Id);

            if (delete == null)
            {
                return new DeleteCustomerCommandDto
                {
                    Success = false,
                    Message = "Not Found"
                };
            }

            else
            { 
                _context.Customer.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new DeleteCustomerCommandDto
                {
                    Success = true,
                    Message = "Successfully retrieved customer"
                };

            }
           
        }
    }
}
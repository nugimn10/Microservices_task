using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Application.Interfaces;
using CustomerServices.Infrastructure.Presistences;
using CustomerServices.Application.Models.Query;
using CustomerServices.Domain.Models;
using MediatR;

namespace CustomerServices.Application.UseCases.Customer.Command.PutCustomer
{
    public class PutCustomerCommandHandler: IRequestHandler<PutCustomerCommand, PutCustomerCommandDto>
    {
        private readonly dbContext _context;
        public PutCustomerCommandHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<PutCustomerCommandDto> Handle(PutCustomerCommand request, CancellationToken cancellationToken)
        {
            var customers = _context.Customer.Find(request.DataD.Attributes.id);

            customers.fullname = request.DataD.Attributes.fullname;
            customers.username = request.DataD.Attributes.username;
            customers.birthdate = request.DataD.Attributes.birthdate;
            customers.passowrd = request.DataD.Attributes.passowrd;
            customers.kelamin = request.DataD.Attributes.kelamin;
            customers.email = request.DataD.Attributes.email;
            customers.phoneNumber = request.DataD.Attributes.phoneNumber;
            customers.updated_at = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);

            await _context.SaveChangesAsync(cancellationToken);

            return new PutCustomerCommandDto
            {
                Success = true,
                Message = "Customer successfully updated",
            };
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
// using CustomerServices.Application.Interfaces;
using CustomerServices.Domain.Models;
using CustomerServices.Application.Interfaces;
using CustomerServices.Infrastructure.Presistences;
using CustomerServices.Application.Models.Query;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace CustomerServices.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandDto>
    {
        private readonly dbContext _context;

        public CreateCustomerCommandHandler (dbContext context)
        {
            _context = context;
        }
        public async Task<CreateCustomerCommandDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            var customer = new Domain.Models.CustomerD
            {
                fullname = request.DataD.Attributes.fullname,
                username = request.DataD.Attributes.username,
                birthdate = request.DataD.Attributes.birthdate,
                passowrd = request.DataD.Attributes.passowrd,
                kelamin = request.DataD.Attributes.kelamin,
                email = request.DataD.Attributes.email,
                phoneNumber = request.DataD.Attributes.phoneNumber
            };
            if (request.DataD.Attributes.kelamin == "male")
            {
                customer.gender = Gender.male;
            }
            else if (request.DataD.Attributes.kelamin == "female")
            {
                customer.gender = Gender.female;
            }

            _context.Customer.Add(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateCustomerCommandDto
            {
                Success = true,
                Message = "Creator successfully created",
            };

        }
    }
}
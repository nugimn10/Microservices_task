using MediatR;
using System;
using CustomerServices.Domain.Models;
using CustomerServices.Application.Models.Query;

namespace CustomerServices.Application.UseCases.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommand : RequestData<CustomerD>,IRequest<CreateCustomerCommandDto>
    {
       
    }


}
using CustomerServices.Application.Models.Query;
using CustomerServices.Domain.Models;
using System;
using MediatR;

namespace CustomerServices.Application.UseCases.Customer.Command.PutCustomer
{
    public class PutCustomerCommand : RequestData<CustomerD>,IRequest<PutCustomerCommandDto>
    {

    }
}
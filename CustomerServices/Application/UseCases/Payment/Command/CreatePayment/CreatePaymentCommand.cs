using MediatR;
using System;
using CustomerServices.Domain.Models;
using CustomerServices.Application.Models.Query;

namespace CustomerServices.Application.UseCases.Payment.Command.CreatePayment
{
    public class CreatePaymentCommand : RequestData<Customer_Payment_Card>, IRequest<CreatePaymentCommandDto>
    {

    }


}
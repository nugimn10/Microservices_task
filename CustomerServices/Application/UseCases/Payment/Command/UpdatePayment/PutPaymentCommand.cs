using CustomerServices.Domain.Models;
using CustomerServices.Application.Models.Query;
using System;
using MediatR;

namespace CustomerServices.Application.UseCases.Payment.Command.PutPayment
{
    public class PutPaymentCommand : RequestData<Customer_Payment_Card>,IRequest<PutPaymentCommandDto>
    {


    }

}
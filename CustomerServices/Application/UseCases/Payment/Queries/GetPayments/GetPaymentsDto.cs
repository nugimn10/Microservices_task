using CustomerServices.Domain.Models;
using CustomerServices.Application.Models.Query;
using System.Collections.Generic;

namespace CustomerServices.Application.UseCases.Payment.Queries.GetPayments
{
    public class GetPaymentsDto : BaseDto
    {
        public IList<Customer_Payment_Card> Data { get; set; }
    }
}
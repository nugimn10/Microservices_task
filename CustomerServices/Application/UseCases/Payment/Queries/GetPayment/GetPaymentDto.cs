using CustomerServices.Domain.Models;
using CustomerServices.Application.Models.Query;

namespace CustomerServices.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentDto : BaseDto
    {
        public Customer_Payment_Card Data { get; set; }
    }
}
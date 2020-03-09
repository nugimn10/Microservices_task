
using CustomerServices.Domain.Models;
using CustomerServices.Application.Models.Query;

namespace CustomerServices.Application.UseCases.Customer.Queries.GetCustomer
{
    public class GetCustomerDto : BaseDto
    {
        public CustomerD Data { get; set; }
    }
}
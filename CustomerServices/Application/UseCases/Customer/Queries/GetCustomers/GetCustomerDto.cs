using CustomerServices.Domain.Models;
using CustomerServices.Application.Models.Query;
using System.Collections.Generic;

namespace CustomerServices.Application.UseCases.Customer.Queries.GetCustomers
{
    public class GetCustomersDto : BaseDto
    {
        public IList<CustomerD> Data { get; set; }
    }
}
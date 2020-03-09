using MerchantServices.Domain.Models;
using MerchantServices.Application.Models.Query;
using System.Collections.Generic;

namespace MerchantServices.Application.UseCases.Merchant.Queries.GetMerchants
{
    public class GetMerchantsDto : BaseDto
    {
        public IList<MerchantD> Data { get; set; }
    }
}
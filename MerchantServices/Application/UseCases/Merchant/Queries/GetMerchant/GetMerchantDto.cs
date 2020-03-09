using MerchantServices.Domain.Models;
using MerchantServices.Application.Models.Query;

namespace MerchantServices.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantDto : BaseDto
    {
        public MerchantD Data { get; set; }
    }
}
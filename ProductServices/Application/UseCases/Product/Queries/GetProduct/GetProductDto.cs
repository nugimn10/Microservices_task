using ProductServices.Domain.Models;
using ProductServices.Application.Models.Query;

namespace ProductServices.Application.UseCases.Product.Queries.GetProduct
{
    public class GetProductDto : BaseDto
    {
        public ProductD Data { get; set; }
    }
}
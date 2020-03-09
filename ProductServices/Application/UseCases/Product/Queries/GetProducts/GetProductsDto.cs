using ProductServices.Domain.Models;
using ProductServices.Application.Models.Query;
using System.Collections.Generic;

namespace ProductServices.Application.UseCases.Product.Queries.GetProducts
{
    public class GetProductsDto : BaseDto
    {
        public IList<ProductD> Data { get; set; }
    }
}
using FluentValidation;

namespace ProductServices.Application.UseCases.Product.Queries.GetProducts
{
    public class GetPaymentsValidation : AbstractValidator<GetProductsQuery>
    {
        public GetPaymentsValidation()
        {

        }
    }
}
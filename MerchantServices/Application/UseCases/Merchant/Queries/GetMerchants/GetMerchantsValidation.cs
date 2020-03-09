using FluentValidation;

namespace MerchantServices.Application.UseCases.Merchant.Queries.GetMerchants
{
    public class GetMErchantsValidation : AbstractValidator<GetMerchantsQuery>
    {
        public GetMErchantsValidation()
        {
            RuleFor(x => x.id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
          
        }
    }
}
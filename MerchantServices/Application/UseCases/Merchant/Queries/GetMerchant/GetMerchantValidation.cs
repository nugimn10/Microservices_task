using FluentValidation;

namespace MerchantServices.Application.UseCases.Merchant.Queries.GetMerchant
{
    public class GetMerchantValidator : AbstractValidator<GetMerchantQuery>
    {
        public GetMerchantValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).NotEmpty().WithMessage("Id harus terdaftar");
          
        }
    }
}
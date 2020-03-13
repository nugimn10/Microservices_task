using FluentValidation;

namespace CustomerServices.Application.UseCases.Payment.Queries.GetPayments
{
    public class GetPaymentsValidation : AbstractValidator<GetPaymentsQuery>
    {
        public GetPaymentsValidation()
        {
          
        }
    }
}
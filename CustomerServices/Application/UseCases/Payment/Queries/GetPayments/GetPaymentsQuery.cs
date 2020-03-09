using MediatR;

namespace CustomerServices.Application.UseCases.Payment.Queries.GetPayments
{
    public class GetPaymentsQuery: IRequest<GetPaymentsDto>
    {
        public int id { get; set; }
    }
}
using MediatR;

namespace CustomerServices.Application.UseCases.Payment.Queries.GetPayment
{
    public class GetPaymentQuery : IRequest<GetPaymentDto>
    {
        public int Id { get; set; }

        public GetPaymentQuery(int id)
        {
            Id = id;
        }
    }
}
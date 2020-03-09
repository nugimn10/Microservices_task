using MediatR;
using CustomerServices.Domain.Models;

namespace CustomerServices.Application.UseCases.Payment.Command.DeletePayment
{
    public class DeletePaymentCommand : IRequest<DeletePaymentCommandDto>
    {
        public int id { get; set; }

        public DeletePaymentCommand(int Id)
        {
            id = Id;
        }
    }
}
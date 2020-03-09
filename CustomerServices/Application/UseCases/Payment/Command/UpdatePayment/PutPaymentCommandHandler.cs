using System;
using System.Threading;
using System.Threading.Tasks;
using CustomerServices.Infrastructure.Presistences;
using CustomerServices.Application.Models.Query;
using CustomerServices.Domain.Models;
using MediatR;

namespace CustomerServices.Application.UseCases.Payment.Command.PutPayment
{

    public class PutMerchantCommandHandler: IRequestHandler<PutPaymentCommand, PutPaymentCommandDto>
    {
        private readonly dbContext _context;
        public PutMerchantCommandHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<PutPaymentCommandDto> Handle(PutPaymentCommand request, CancellationToken cancellationToken)
        {
            var payment_Card = _context.Customer_Payment_Cards.Find(request.DataD.Attributes.id);

            payment_Card.customer_id = request.DataD.Attributes.customer_id;
            payment_Card.name_no_card = request.DataD.Attributes.name_no_card;
            payment_Card.exp_month = request.DataD.Attributes.exp_month;
            payment_Card.exp_year = request.DataD.Attributes.exp_year;
            payment_Card.postal_code = request.DataD.Attributes.postal_code;
            payment_Card.credit_card_number = request.DataD.Attributes.credit_card_number;
            payment_Card.updated_at = Convert.ToInt64((DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds);


            await _context.SaveChangesAsync(cancellationToken);

            return new PutPaymentCommandDto
            {
                Success = true,
                Message = "Customer successfully updated",
            };
        }
    }

}
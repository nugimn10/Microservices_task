using System.Threading;
using System.Threading.Tasks;
// using MerchantServices.Application.Interfaces;
using MerchantServices.Infrastructure.Presistences;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace MerchantServices.Application.UseCases.Merchant.Command.CreateMerchant
{
    public class CreateMerchantCommandHandler : IRequestHandler<CreateMerchantCommand, CreateMerchantCommandDto>
    {
        private readonly dbContext _context;

        public CreateMerchantCommandHandler (dbContext context)
        {
            _context = context;
        }
        public async Task<CreateMerchantCommandDto> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
        {

            var merchant = new Domain.Models.MerchantD
            {
                name = request.DataD.Attributes.name,
                address = request.DataD.Attributes.address
            };

            _context.Add(merchant);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateMerchantCommandDto
            {
                Success = true,
                Message = "Creator successfully created",
            };

        }
    }
}
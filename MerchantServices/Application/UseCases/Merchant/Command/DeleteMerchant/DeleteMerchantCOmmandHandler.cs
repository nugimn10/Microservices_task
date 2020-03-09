using System.Threading;
using System.Threading.Tasks;
using MerchantServices.Infrastructure.Presistences;
using MerchantServices.Domain.Models;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace MerchantServices.Application.UseCases.Merchant.Command.DeleteMerchant
{
    public class DeleteMerchantCommandHandler : IRequestHandler<DeleteMerchantCommand, DeleteMerchantCommandDto>
    {
        private readonly dbContext _context;

        public DeleteMerchantCommandHandler(dbContext context)
        {
            _context = context;
        }
        public async Task<DeleteMerchantCommandDto> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
        {
            var delete = await _context.Merchant.FindAsync(request.id);

            if (delete == null)
            {
                return new DeleteMerchantCommandDto
                {
                    Success = false,
                    Message = "Not Found"
                };
            }

            else
            { 
                _context.Merchant.Remove(delete);
                await _context.SaveChangesAsync(cancellationToken);

                return new DeleteMerchantCommandDto
                {
                    Success = true,
                    Message = "Successfully retrieved customer"
                };

            }
           
        }
    }
}
using MediatR;
using MerchantServices.Domain.Models;

namespace MerchantServices.Application.UseCases.Merchant.Command.DeleteMerchant
{
    public class DeleteMerchantCommand : IRequest<DeleteMerchantCommandDto>
    {
        public int id { get; set; }

        public DeleteMerchantCommand(int Id)
        {
            id = Id;
        }
    }
}
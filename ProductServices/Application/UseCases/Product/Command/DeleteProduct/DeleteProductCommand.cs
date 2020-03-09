using MediatR;
using ProductServices.Domain.Models;

namespace ProductServices.Application.UseCases.Product.Command.DeleteProduct
{
    public class DeleteProductCommand : IRequest<DeleteProductCommandDto>
    {
        public int id { get; set; }

        public DeleteProductCommand(int Id)
        {
            id = Id;
        }
    }
}
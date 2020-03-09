using System.Threading;
using System.Threading.Tasks;
// using ProductServices.Application.Interfaces;
using ProductServices.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace ProductServices.Application.UseCases.Product.Command.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandDto>
    {
        private readonly dbContext _context;

        public CreateProductCommandHandler (dbContext context)
        {
            _context = context;
        }
        public async Task<CreateProductCommandDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var product = new Domain.Models.ProductD
            {
                name = request.DataD.Attributes.name,
                price = request.DataD.Attributes.price
            };

            _context.Product.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateProductCommandDto
            {
                Success = true,
                Message = "Creator successfully created",
            };

        }
    }
}
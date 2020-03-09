  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductServices.Application.UseCases.Product.Queries.GetProduct;
using ProductServices.Application.UseCases.Product.Queries.GetProducts;
using ProductServices.Application.UseCases.Product.Command.CreateProduct;
using ProductServices.Application.UseCases.Product.Command.PutProduct;
using ProductServices.Application.UseCases.Product.Command.DeleteProduct;
using ProductServices.Infrastructure.Presistence;

namespace ProductServices.Presenter.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
         private IMediator _mediatr;

        public ProductController(IMediator Mediator)
        {
            _mediatr = Mediator;
        }
       
        [HttpGet]
        public async Task<ActionResult<GetProductsDto>> GetCustomer()
        {
            var result = new GetProductsQuery();
            return Ok(await _mediatr.Send(result));
        }

        [HttpPost]
        public async Task<ActionResult> PostCustomer( CreateProductCommand payload)
        {
            var result = await _mediatr.Send(payload);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductDto>> GetCustomerById(int id)
        {
            var result = new GetProductQuery(id);
            return Ok(await _mediatr.Send(result));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int ID, PutProductCommand data)
        {
            data.DataD.Attributes.id = ID;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand(id);
            var result = await _mediatr.Send(command);

            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });

        }
    }
}
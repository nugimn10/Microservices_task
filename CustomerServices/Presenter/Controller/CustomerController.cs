  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CustomerServices.Application.UseCases.Customer.Queries.GetCustomer;
using CustomerServices.Application.UseCases.Customer.Queries.GetCustomers;
using CustomerServices.Application.UseCases.Customer.Command.CreateCustomer;
using CustomerServices.Application.UseCases.Customer.Command.DeleteCustomer;
using CustomerServices.Application.UseCases.Customer.Command.PutCustomer;
using CustomerServices.Infrastructure.Presistences;

namespace CustomerServices.Presenter.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediatr;

        public CustomerController(IMediator Mediator)
        {
            _mediatr = Mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetCustomersDto>> GetCustomer()
        {
            var result = new GetCustomersQuery();
            return Ok(await _mediatr.Send(result));
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer( CreateCustomerCommand payload)
        {
            var result = await _mediatr.Send(payload);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerDto>> GetCustomerById(int id)
        {
            var result = new GetCustomerQuery(id);
            return Ok(await _mediatr.Send(result));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int ID, PutCustomerCommand data)
        {
            data.DataD.Attributes.id = ID;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand(id);
            var result = await _mediatr.Send(command);

            return result != null ? (ActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });

        }
    }
}
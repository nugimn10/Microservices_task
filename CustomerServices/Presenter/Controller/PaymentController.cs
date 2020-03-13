  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CustomerServices.Application.UseCases.Payment.Command.DeletePayment;
using CustomerServices.Application.UseCases.Payment.Command.PutPayment;
using CustomerServices.Application.UseCases.Payment.Queries.GetPayment;
using CustomerServices.Application.UseCases.Payment.Queries.GetPayments;
using CustomerServices.Application.UseCases.Payment.Command.CreatePayment;
using CustomerServices.Infrastructure.Presistences;
using Microsoft.AspNetCore.Authorization;

namespace CustomerServices.Presenter.Controllers
{
    [ApiController]
    [Route("card")]
    public class PaymentController : ControllerBase
    {
        private IMediator _mediatr;

        public PaymentController(IMediator Mediator)
        {
            _mediatr = Mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetPaymentsDto>> GetCustomer()
        {
            var result = new GetPaymentsQuery();
            return Ok(await _mediatr.Send(result));
        }

        [HttpPost]
        public async Task<ActionResult> PostCustomer( CreatePaymentCommand payload)
        {
            var result = await _mediatr.Send(payload);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPaymentDto>> GetCustomerById(int id)
        {
            var result = new GetPaymentQuery(id);
            return Ok(await _mediatr.Send(result));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int ID, PutPaymentCommand data)
        {
            data.DataD.Attributes.id = ID;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePaymentCommand(id);
            var result = await _mediatr.Send(command);

            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "not found" });

        }
    }
}
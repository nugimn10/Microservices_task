using MediatR;
using System;
using MerchantServices.Domain.Models;
using MerchantServices.Application.Models.Query;

namespace MerchantServices.Application.UseCases.Merchant.Command.CreateMerchant
{
    public class CreateMerchantCommand : RequestData<MerchantD>,IRequest<CreateMerchantCommandDto>
    
    {

    }


}
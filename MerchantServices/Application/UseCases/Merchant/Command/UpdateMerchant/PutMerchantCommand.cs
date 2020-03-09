using MerchantServices.Domain.Models;
using System;
using MerchantServices.Application.Models.Query;
using MediatR;

namespace MerchantServices.Application.UseCases.Merchant.Command.PutMerchant
{
    public class PutMerchantCOmmand : RequestData<MerchantD>,IRequest<PutMerchantCommandDto>
    {

    }

}
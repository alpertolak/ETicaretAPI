using ETicaretAPI.Application.Absractions.Services;
using MediatR;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Basket.UpdateQuantity
{
    public class UpdateQuantityCommandHandler : IRequestHandler<UpdateQuantityCommandRequest, UpdateQuantityCommandResponse>
    {
        readonly IBasketService _basketService;

        public UpdateQuantityCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<UpdateQuantityCommandResponse> Handle(UpdateQuantityCommandRequest request, CancellationToken cancellationToken)
        {
            try
             {
                await _basketService.UpdateQuantityAsync(new()
                {
                    BasketItemId = request.BasketItemId,
                    Qantity = request.Quantity
                });
                return new();
            }
            catch (Exception)
            {
                throw new Exception("Urun Miktari Guncellenirken Bir Hata Olustu.");
            }
            
        }
    }
}

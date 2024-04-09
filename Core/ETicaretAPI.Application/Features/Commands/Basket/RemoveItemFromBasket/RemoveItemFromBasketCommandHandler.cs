using ETicaretAPI.Application.Absractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Basket
{
    public class RemoveItemFromBasketCommandHandler : IRequestHandler<RemoveItemFromBasketCommandRequest, RemoveItemFromBasketCommandResponse>
    {
        readonly IBasketService _basketService;

        public RemoveItemFromBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<RemoveItemFromBasketCommandResponse> Handle(RemoveItemFromBasketCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _basketService.RemoveItemFromBasketAsync(request.BasketItemId);
                return new();
            }
            catch (Exception)
            {
                throw new Exception("Ürün Sepetten Silinirken Bir Hata Oluştu.");
            }

        }
    }
}

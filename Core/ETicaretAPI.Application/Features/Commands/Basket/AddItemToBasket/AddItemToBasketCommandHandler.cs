using ETicaretAPI.Application.Absractions.Services;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.Basket
{
    public class AddItemToBasketCommandHandler : IRequestHandler<AddItemToBasketCommandRequest, AddItemToBasketCommandResponse>
    {
        readonly IBasketService _basketService;

        public AddItemToBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<AddItemToBasketCommandResponse> Handle(AddItemToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _basketService.AddItemToBasketAsync(new()
                {
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                });
                return new();
            }
            catch (Exception)
            {
                throw new Exception("Ürün Sepete Eklenirken Bir Hata Oluştu.");
            }
        }
    }
}

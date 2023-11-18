using ETicaretAPI.Application.ViewModels.Basket;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Absractions.Services
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> getBasketItemsAsync();

        public Task AddItemToBasketAsync(VM_Create_BasketItem basketItem);

        public Task UpdateQuantityAsync(VM_Update_BasketItem basketItem);
            
        public Task RemoveItemFromBasketAsync(string basketItemId);
    }
}

using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class BasketItem : EntityBase
    {
        public Guid BasketId { get; set; }

        public Guid ProductId { get; set; }

        public EntityProduct Product { get; set; }

        public EntityBasket Basket { get; set; }

        public int Quantity { get; set; }

    }
}

using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Domain.Entities
{
    public class EntityBasket : EntityBase
    {

        public string UserId { get; set; }

        public AppUser User { get; set; }

        public EntityOrder Order { get; set; }

        public ICollection<BasketItem> BasketItems { get; set; }

    }
}

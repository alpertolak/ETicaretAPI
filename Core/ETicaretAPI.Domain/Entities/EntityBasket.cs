using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class EntityBasket : EntityBase
    {

        public AppUser User { get; set; }

        public ICollection<BasketItem> BasketItems { get; set; }

    }
}

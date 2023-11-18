using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class EntityOrder : EntityBase
    {
        public Guid CustomerId { get; set; }

        public String Description { get; set; }
        public String Address { get; set; }

        public EntityBasket Basket { get; set; }
        public ICollection<EntityProduct> Products { get; set; }
        public EntityCustomer Customer { get; set; }

    }
}

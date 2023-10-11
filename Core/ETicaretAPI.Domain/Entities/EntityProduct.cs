using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class EntityProduct : EntityBase
    {
        public String Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }

        public ICollection<EntityOrder> Orders { get; set; }

        public ICollection<ProductImagesFile> ProductImageFiles { get; set; }

    }
}

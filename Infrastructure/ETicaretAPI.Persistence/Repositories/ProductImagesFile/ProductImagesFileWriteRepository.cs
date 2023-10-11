using ETicaretAPI.Application.Repository;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ProductImagesFileWriteRepository : WriteRepository<ProductImagesFile>, IProductImageFileWriteRepository
    {
        public ProductImagesFileWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}

using ETicaretAPI.Application.Repository;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class InvoiceReadRepository : ReadRepository<Domain.Entities.InvoiceFile>, IInvoiceReadRepository
    {
        public InvoiceReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}

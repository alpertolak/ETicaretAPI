using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repository;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class InvoiceWriteRepository : WriteRepository<Domain.Entities.InvoiceFile>, IInvoiceWriteRepository
    {
        public InvoiceWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}

using ETicaretAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repository
{
    public interface IFileWriteRepository :IWriteRepository<ETicaretAPI.Domain.Entities.File>
    {
    }
}

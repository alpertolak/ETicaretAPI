using ETicaretAPI.Application.RequestParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllRroduct
{
    public class GetAllRroductQueryRequest : IRequest<GetAllProductQueryResponse>
    {
        public int page { get; set; } = 0;
        public int size { get; set; } = 5;
    }
}

using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllRroduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllRroductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;
        private ILogger<GetAllProductQueryHandler> _logger;

        public GetAllProductQueryHandler(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            ILogger<GetAllProductQueryHandler> logger)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _logger = logger;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllRroductQueryRequest request, CancellationToken cancellationToken)
        {
            //_logger.LogInformation("Get All Products");

            var totalCount = _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository.GetAll(false).Skip(request.size * request.page)
                .Take(request.size)
                .Include(p => p.ProductImageFiles)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Stock,
                    p.Price,
                    p.CreatedDate,
                    p.UpdatedDate,
                    p.ProductImageFiles
                }).ToList();

            return new()
            {
                Products = products,
                TotalProductCount = totalCount,
            };
        }
    }
}

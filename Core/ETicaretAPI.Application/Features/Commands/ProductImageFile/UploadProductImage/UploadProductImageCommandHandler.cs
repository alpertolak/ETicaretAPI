using ETicaretAPI.Application.Absractions.Storage;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Repository;
using ETicaretAPI.Domain.Entities;
using MediatR;

namespace ETicaretAPI.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IStorageService _storageService;

        public UploadProductImageCommandHandler(
            IProductReadRepository productReadRepository,
            IProductWriteRepository productWriteRepository,
            IProductImageFileWriteRepository productImageWriteRepository,
            IStorageService storageService)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _productImageFileWriteRepository = productImageWriteRepository;
            _storageService = storageService;
        }

        public async Task<UploadProductImageCommandResponse> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);

            Domain.Entities.EntityProduct product = await _productReadRepository.GetByIdAsync(request.Id); // veri tabanında resimi eşleştirmek için id bilgisi üzerinden ürün bilgileri çekiliyor

            await _productImageFileWriteRepository.AddRangeAsync(result.Select(r => new ProductImagesFile
            {
                fileName = r.fileName,
                filePath = Path.Combine(r.pathOrContainerName, r.fileName),
                Storage = _storageService.StorageName,
                Products = new List<EntityProduct> { product }

            }).ToList());

            await _productImageFileWriteRepository.SaveAsync();
            return new();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.ProductImageFile.GetProductImages
{
    public class GetProductImagesQueryResponse
    {
        public string? filePath { get; set; }
        public string? fileName { get; set; }
        public Guid Id { get; set; }
        public Boolean showcase { get; set; }
    }
}

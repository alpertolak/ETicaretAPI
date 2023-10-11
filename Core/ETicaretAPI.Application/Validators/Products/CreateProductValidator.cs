using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator: AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Ürün adı boş olamaz")
                .MinimumLength(5)
                .MaximumLength(100)
                    .WithMessage("Ürün adı 5 ile 100 karakter arasında olmalıdır");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Stok bilgisi boş olamaz")
                .Must(s => s >= 0)
                    .WithMessage("stok bilgisi negatif bir değer olamaz");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Fiyat bilgisi boş olamaz")
                .Must(s => s >= 0)
                    .WithMessage("Fiyat bilgisi negatif bir değer olamaz");
        }
    }
}

using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x=> x.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez");
            RuleFor(x=> x.Name).MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır");
            RuleFor(x=> x.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez");
            RuleFor(x=> x.Price).GreaterThan(0).WithMessage("Ürün fiyatı 0'dan büyük olmalıdır");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Ürün stok adedi boş geçilemez");
        }
    }
}

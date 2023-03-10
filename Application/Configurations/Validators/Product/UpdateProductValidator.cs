using Contracts.Product;
using FluentValidation;

namespace Application.Configurations.Validators.Product;

public class UpdateProductValidator : AbstractValidator<UpdateProductRequestContract>
{
    public UpdateProductValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
        RuleFor(p => p.Name).NotEmpty().Length(2, 30);
        RuleFor(p => p.BarCode).Length(13, 19);
    }
}
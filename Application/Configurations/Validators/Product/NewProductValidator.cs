using Contracts.Product;
using FluentValidation;

namespace Application.Configurations.Validators.Product;

public class NewProductValidator : AbstractValidator<NewProductRequestContract>
{
    public NewProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty().Length(2, 30);
        RuleFor(p => p.BarCode).Length(13, 19);
    }
}
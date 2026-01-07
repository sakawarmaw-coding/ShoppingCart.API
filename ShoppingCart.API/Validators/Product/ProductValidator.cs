namespace ShoppingCart.API.Validators.Product;

public class ProductValidator : AbstractValidator<ProductReqModel>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Product Name cannot be empty.");
        RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("Price cannot be zero.");
    }
}
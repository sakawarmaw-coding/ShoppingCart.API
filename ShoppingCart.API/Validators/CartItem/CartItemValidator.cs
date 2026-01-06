namespace ShoppingCart.API.Validators.CartItem;

public class CartItemValidator : AbstractValidator<CartItemReqModel>
{
    public CartItemValidator()
    {
        RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("UserId cannot be empty.");
        RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("ProductId cannot be empty.");
        RuleFor(x => x.Quantity).NotNull().NotEmpty().WithMessage("Quantity cannot be zero.");
    }
}

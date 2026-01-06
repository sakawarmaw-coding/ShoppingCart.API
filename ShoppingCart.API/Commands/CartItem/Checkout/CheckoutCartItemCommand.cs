namespace ShoppingCart.API.Commands.CartItem.Checkout;

public class CheckoutCartItemCommand : IRequest<int>
{
    public int UserId { get; set; }
}


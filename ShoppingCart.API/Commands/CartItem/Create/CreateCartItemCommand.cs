namespace ShoppingCart.API.Commands.CartItem.Create;

public class CreateCartItemCommand : IRequest<int>
{
    public CartItemReqModel CartItemReqModel { get; set; }
}


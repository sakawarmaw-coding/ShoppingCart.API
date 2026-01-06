namespace ShoppingCart.API.Commands.CartItem.Delete;

public class DeleteCartItemCommand : IRequest<int>
{
    public int Id { get; set; }
}


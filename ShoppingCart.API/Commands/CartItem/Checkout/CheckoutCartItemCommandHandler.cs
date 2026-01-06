namespace ShoppingCart.API.Commands.CartItem.Checkout;

public class CheckoutCartItemCommandHandler : IRequestHandler<CheckoutCartItemCommand, int>
{
    private readonly ICartItemRepository _cartRepository;

    public CheckoutCartItemCommandHandler(ICartItemRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<int> Handle(
        CheckoutCartItemCommand request,
        CancellationToken cancellationToken
    )
    {
        return await _cartRepository.CheckOutCartItemAsync(request.UserId);
    }
}



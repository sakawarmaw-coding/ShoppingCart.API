namespace ShoppingCart.API.Commands.CartItem.Create;

public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, int>
{
    private readonly ICartItemRepository _cartRepository;

    public CreateCartItemCommandHandler(ICartItemRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<int> Handle(
        CreateCartItemCommand request,
        CancellationToken cancellationToken
    )
    {
        return await _cartRepository.CreateCartItemAsync(request.CartItemReqModel);
    }
}



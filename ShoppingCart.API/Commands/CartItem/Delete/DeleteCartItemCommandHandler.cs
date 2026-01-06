namespace ShoppingCart.API.Commands.CartItem.Delete;

public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, int>
{
    private readonly ICartItemRepository _cartRepository;

    public DeleteCartItemCommandHandler(ICartItemRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<int> Handle(
        DeleteCartItemCommand request,
        CancellationToken cancellationToken
    )
    {
        return await _cartRepository.DeleteCartItemAsync(request.Id);
    }
}


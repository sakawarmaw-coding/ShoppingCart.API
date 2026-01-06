namespace ShoppingCart.API.Queries.CartItem.GetCartItemListQuery;

public class GetCartItemListQueryHandler
    : IRequestHandler<GetCartItemListQuery, CartItemListRespModel>
{
    private readonly ICartItemRepository _cartItemRepository;

    public GetCartItemListQueryHandler(ICartItemRepository cartItemRepository)
    {
        _cartItemRepository = cartItemRepository;
    }

    public async Task<CartItemListRespModel> Handle(
        GetCartItemListQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _cartItemRepository.GetCartItemListAsync();
    }
}


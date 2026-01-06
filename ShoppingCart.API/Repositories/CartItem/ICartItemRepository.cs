namespace ShoppingCart.API.Repositories.CartItem
{
    public interface ICartItemRepository
    {
        Task<CartItemListRespModel> GetCartItemListAsync();
        Task<int> CreateCartItemAsync(CartItemReqModel requestModel);
        Task<int> CheckOutCartItemAsync(int UserId);
        Task<int> DeleteCartItemAsync(int id);
    }
}

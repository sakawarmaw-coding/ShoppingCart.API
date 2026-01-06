namespace ShoppingCart.API.Business.Interface
{
    public interface ICartItemDA
    {
        Task<CartItemListRespModel> GetCartItemListAsync();
        Task<int> CreateCartItemAsync(CartItemReqModel requestModel);
        Task<int> CheckOutCartItemAsync(int userId);
        Task<int> DeleteCartItemAsync(int id);
    }
}

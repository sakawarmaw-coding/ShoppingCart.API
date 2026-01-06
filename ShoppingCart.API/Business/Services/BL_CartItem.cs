namespace ShoppingCart.API.Business.Services;

public class BL_CartItem : ICartItemBL
{
    private readonly DA_CartItem _dA_CartItem;
    private readonly CartItemValidator _cartValidator;
    private readonly AppDbContext _appDbContext;

    public BL_CartItem(
        DA_CartItem dA_CartItem,
        CartItemValidator cartValidator,
        AppDbContext appDbContext
    )
    {
        _dA_CartItem = dA_CartItem;
        _cartValidator = cartValidator;
        _appDbContext = appDbContext;
    }

    public async Task<CartItemListRespModel> GetCartItemListAsync()
    {
        return await _dA_CartItem.GetCartItemListAsync();
    }

    public async Task<int> CreateCartItemAsync(CartItemReqModel requestModel)
    {
        ValidationResult validationResult = await _cartValidator.ValidateAsync(requestModel);
        StringBuilder errors = new();

        if (!validationResult.IsValid)
        {
            validationResult.Errors.ForEach(err => errors.Append(err.ErrorMessage));
            throw new Exception(errors.ToString());
        }

        return await _dA_CartItem.CreateCartItemAsync(requestModel);
    }

    public async Task<int> CheckOutCartItemAsync(int UserId)
    {
        if (UserId <= 0)
            throw new Exception("UserId cannot be empty.");

        return await _dA_CartItem.CheckOutCartItemAsync(UserId);
    }

    public async Task<int> DeleteCartItemAsync(int Id)
    {
        if (Id <= 0)
            throw new Exception("Id is invalid.");

        return await _dA_CartItem.DeleteCartItemAsync(Id);
    }
}


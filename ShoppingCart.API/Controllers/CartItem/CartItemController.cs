
namespace ShoppingCart.API.Controllers.CartItem;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CartItemController : BaseController
{
    private readonly ICartItemBL _bL_CartItem;

    public CartItemController(ICartItemBL bL_CartItem)
    {
        _bL_CartItem = bL_CartItem;
    }

    [HttpGet("cartItemList")]
    public async Task<IActionResult> GetCartItems()
    {
        try
        {
            var lst = await _bL_CartItem.GetCartItemListAsync();
            return Content(lst);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpPost("createCartItem")]
    public async Task<IActionResult> CreateCartItem([FromBody] CartItemReqModel requestModel)
    {
        try
        {
            int result = await _bL_CartItem.CreateCartItemAsync(requestModel);
            return result > 0 ? Created("CartItem Created.") : BadRequest("Creating Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpPatch("checkoutCartItem/{userId}")]
    public async Task<IActionResult> CheckOutCartItem(int userId)
    {
        try
        {
            int result = await _bL_CartItem.CheckOutCartItemAsync(userId);
            return result > 0 ? Accepted("Checkout Successfully.") : BadRequest("Checkout Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpDelete("deleteCartItem/{id}")]
    public async Task<IActionResult> DeleteCartItem(int id)
    {
        try
        {
            int result = await _bL_CartItem.DeleteCartItemAsync(id);
            return result > 0 ? Accepted("CartItem Deleted.") : BadRequest("Delete Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }
}


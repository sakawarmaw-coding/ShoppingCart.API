using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.API.Business.Interface;

namespace ShoppingCart.API.Controllers.CartItem
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : BaseController
    {
        private readonly ICartItemBL _bL_CartItem;

        public CartItemController(ICartItemBL bL_CartItem)
        {
            _bL_CartItem = bL_CartItem;
        }

        [HttpGet]
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

        [HttpPost]
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> CheckOutCartItem(int UserId)
        {
            try
            {
                int result = await _bL_CartItem.CheckOutCartItemAsync(UserId);
                return result > 0 ? Accepted("Checkout Successfully.") : BadRequest("Checkout Fail.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int Id)
        {
            try
            {
                int result = await _bL_CartItem.DeleteCartItemAsync(Id);
                return result > 0 ? Accepted("CartItem Deleted.") : BadRequest("Delete Fail.");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}

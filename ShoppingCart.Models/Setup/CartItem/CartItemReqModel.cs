
namespace ShoppingCart.Models.Setup.CartItem;

public class CartItemReqModel
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}

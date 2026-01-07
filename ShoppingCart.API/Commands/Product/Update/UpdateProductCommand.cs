namespace ShoppingCart.API.Commands.Product.Update;

public class UpdateProductCommand : IRequest<int>
{
    public ProductReqModel ProductReqModel { get; set; }
    public int Id { get; set; }
}
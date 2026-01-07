namespace ShoppingCart.API.Commands.Product.Create;

public class CreateProductCommand : IRequest<int>
{
    public ProductReqModel ProductReqModel { get; set; }
}

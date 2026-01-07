namespace ShoppingCart.API.Commands.Product.Delete;

public class DeleteProductCommand : IRequest<int>
{
    public int Id { get; set; }
}


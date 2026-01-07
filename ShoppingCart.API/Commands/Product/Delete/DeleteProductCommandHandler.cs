namespace ShoppingCart.API.Commands.Product.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Handle(
        DeleteProductCommand request,
        CancellationToken cancellationToken
    )
    {
        return await _productRepository.DeleteProductAsync(request.Id);
    }
}




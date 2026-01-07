namespace ShoppingCart.API.Commands.Product.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken
    )
    {
        return await _productRepository.CreateProductAsync(request.ProductReqModel);
    }
}

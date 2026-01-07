namespace ShoppingCart.API.Commands.Product.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Handle(
        UpdateProductCommand request,
        CancellationToken cancellationToken
    )
    {
        return await _productRepository.UpdateProductAsync(
            request.ProductReqModel,
            request.Id
        );
    }
}



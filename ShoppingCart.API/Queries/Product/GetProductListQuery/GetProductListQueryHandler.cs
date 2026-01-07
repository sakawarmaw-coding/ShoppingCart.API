namespace ShoppingCart.API.Queries.Product.GetProductListQuery;

public class GetProductListQueryHandler
    : IRequestHandler<GetProductListQuery, ProductListRespModel>
{
    private readonly IProductRepository _productRepository;

    public GetProductListQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductListRespModel> Handle(
        GetProductListQuery request,
        CancellationToken cancellationToken
    )
    {
        return await _productRepository.GetProductListAsync();
    }
}




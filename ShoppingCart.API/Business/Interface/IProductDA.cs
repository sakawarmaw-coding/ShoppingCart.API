namespace ShoppingCart.API.Business.Interface;

public interface IProductDA
{
    Task<ProductListRespModel> GetProductListAsync();
    Task<int> CreateProductAsync(ProductReqModel requestModel);
    Task<int> UpdateProductAsync(ProductReqModel requestModel, int Id);
    Task<int> DeleteProductAsync(int id);
}


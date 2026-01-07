namespace ShoppingCart.API.Business.Interface;

public interface IProductBL
{
    Task<ProductListRespModel> GetProductListAsync();
    Task<int> CreateProductAsync(ProductReqModel requestModel);
    Task<int> UpdateProductAsync(ProductReqModel requestModel,int Id);
    Task<int> DeleteProductAsync(int id);
}


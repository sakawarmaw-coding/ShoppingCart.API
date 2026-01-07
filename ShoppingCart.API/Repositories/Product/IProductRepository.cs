namespace ShoppingCart.API.Repositories.Product
{
    public interface IProductRepository
    {
        Task<ProductListRespModel> GetProductListAsync();
        Task<int> CreateProductAsync(ProductReqModel requestModel);
        Task<int> UpdateProductAsync(ProductReqModel requestModel, int Id);
        Task<int> DeleteProductAsync(int id);
    }
}

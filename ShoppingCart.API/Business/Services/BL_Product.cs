using ShoppingCart.API.DataAccess;

namespace ShoppingCart.API.Business.Services;

public class BL_Product : IProductBL
{
    private readonly IProductDA _dA_Product;
    private readonly ProductValidator _productValidator;
    private readonly AppDbContext _appDbContext;

    public BL_Product(
       IProductDA dA_Product,
       ProductValidator productValidator,
       AppDbContext appDbContext
   )
    {
        _dA_Product = dA_Product;
        _productValidator = productValidator;
        _appDbContext = appDbContext;
    }

    public async Task<int> CreateProductAsync(ProductReqModel requestModel)
    {
        ValidationResult validationResult = await _productValidator.ValidateAsync(requestModel);
        StringBuilder errors = new();

        if (!validationResult.IsValid)
        {
            validationResult.Errors.ForEach(err => errors.Append(err.ErrorMessage));
            throw new Exception(errors.ToString());
        }

        return await _dA_Product.CreateProductAsync(requestModel);
    }

    public async Task<int> DeleteProductAsync(int id)
    {
        if (id <= 0)
            throw new Exception("Id is invalid.");

        return await _dA_Product.DeleteProductAsync(id);
    }

    public async Task<ProductListRespModel> GetProductListAsync()
    {
        return await _dA_Product.GetProductListAsync();
    }

    public async Task<int> UpdateProductAsync(ProductReqModel requestModel, int Id)
    {
        if (Id <= 0)
            throw new Exception("Id cannot be empty.");

        return await _dA_Product.UpdateProductAsync(requestModel, Id);
    }
}


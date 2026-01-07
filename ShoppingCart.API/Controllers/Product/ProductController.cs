
namespace ShoppingCart.API.Controllers.Product;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductController : BaseController
{
    private readonly IProductBL _bL_Product;
    public ProductController(IProductBL bL_Product)
    {
        _bL_Product = bL_Product;
    }

    [HttpGet("productList")]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            var lst = await _bL_Product.GetProductListAsync();
            return Content(lst);
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpPost("createProduct")]
    public async Task<IActionResult> CreateProduct([FromBody] ProductReqModel requestModel)
    {
        try
        {
            int result = await _bL_Product.CreateProductAsync(requestModel);
            return result > 0 ? Created("Product Created.") : BadRequest("Creating Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpPatch("updateProduct/{Id}")]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductReqModel requestModel, int Id)
    {
        try
        {
            int result = await _bL_Product.UpdateProductAsync(requestModel, Id);
            return result > 0 ? Accepted("Product Updated.") : BadRequest("Updating Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

    [HttpDelete("deleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            int result = await _bL_Product.DeleteProductAsync(id);
            return result > 0 ? Accepted("Product Deleted.") : BadRequest("Delete Fail.");
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }

}


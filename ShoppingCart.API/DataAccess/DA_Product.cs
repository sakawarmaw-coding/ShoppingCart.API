using ShoppingCart.API.Commands.Product.Create;
using ShoppingCart.API.Commands.Product.Delete;


namespace ShoppingCart.API.DataAccess;

public class DA_Product : IProductDA
{
    private readonly IMediator _mediator;

    public DA_Product(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<int> CreateProductAsync(ProductReqModel reqModel)
    {
        try
        {
            var command = new CreateProductCommand() { ProductReqModel = reqModel };
            return await _mediator.Send(command);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> DeleteProductAsync(int id)
    {
        try
        {
            var command = new DeleteProductCommand() { Id = id };
            return await _mediator.Send(command);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ProductListRespModel> GetProductListAsync()
    {
        try
        {
            var query = new GetProductListQuery();
            var lst = await _mediator.Send(query);

            return lst;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> UpdateProductAsync(ProductReqModel reqModel, int Id)
    {
        try
        {
            var command = new UpdateProductCommand()
            {
                Id = Id,
                ProductReqModel = reqModel
            };
            return await _mediator.Send(command);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}


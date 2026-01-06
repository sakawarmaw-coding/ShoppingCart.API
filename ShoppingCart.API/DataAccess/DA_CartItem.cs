namespace ShoppingCart.API.DataAccess;

public class DA_CartItem : ICartItemDA
{
    private readonly IMediator _mediator;

    public DA_CartItem(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<CartItemListRespModel> GetCartItemListAsync()
    {
        try
        {
            var query = new GetCartItemListQuery();
            var lst = await _mediator.Send(query);

            return lst;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> CreateCartItemAsync(CartItemReqModel reqModel)
    {
        try
        {
            var command = new CreateCartItemCommand() { CartItemReqModel = reqModel };
            return await _mediator.Send(command);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> DeleteCartItemAsync(int id)
    {
        try
        {
            var command = new DeleteCartItemCommand() { Id = id };
            return await _mediator.Send(command);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<int> CheckOutCartItemAsync(int UserId)
    {
        try
        {
            var command = new CheckoutCartItemCommand() { UserId = UserId };
            return await _mediator.Send(command);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}

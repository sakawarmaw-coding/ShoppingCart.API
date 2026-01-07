using Microsoft.EntityFrameworkCore;
using ShoppingCart.DbService.Entities;

namespace ShoppingCart.API.Repositories.CartItem
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public CartItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        #region Get Cart Item List Async

        public async Task<CartItemListRespModel> GetCartItemListAsync()
        {
            try
            {
                var lstCart = await _appDbContext
                    .tblCartItem.AsNoTracking()
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
                var lst = lstCart.Select(x => x.ChangeCartItemModel()).ToList();
                var responseModel = new CartItemListRespModel() { lstCart = lst };

                return responseModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Create Cart Item Async

        public async Task<int> CreateCartItemAsync(CartItemReqModel requestModel)
        {
            try
            {
                string userName = string.Empty;
                string productName = string.Empty;
                var user = _appDbContext.tblUser.FirstOrDefault(x => x.Id == requestModel.UserId);
                if (user is not null)
                {
                    userName = user.UserName;
                }
                var product = _appDbContext.tblProduct.FirstOrDefault(x => x.Id == requestModel.ProductId);
                if (product is not null)
                {
                    productName = product.Name;
                }

                var dataModel = new TblCartItem
                {
                    UserId = requestModel.UserId,
                    UserName= userName,
                    ProductId = requestModel.ProductId,
                    ProductName = productName,
                    Quantity = requestModel.Quantity,
                };
                await _appDbContext.tblCartItem.AddAsync(dataModel);

                return await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region CheckOut Cart Item Async

        public async Task<int> CheckOutCartItemAsync(int UserId)
        {
            try
            {
                var items = _appDbContext.tblCartItem.Where(c => c.UserId == UserId);
                _appDbContext.tblCartItem.RemoveRange(items);
                return await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Delete Cart Item Async

        public async Task<int> DeleteCartItemAsync(int id)
        {
            try
            {
                var item =
                    await _appDbContext
                        .tblCartItem.AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id)
                    ?? throw new Exception("No data found.");
                _appDbContext.Remove(item);
                return await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}

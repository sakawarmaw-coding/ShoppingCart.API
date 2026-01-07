
namespace ShoppingCart.API.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> CreateProductAsync(ProductReqModel requestModel)
        {
            var dataModel = new TblProduct
            {
                Name = requestModel.Name!,
                Price = requestModel.Price,
            };
            await _appDbContext.tblProduct.AddAsync(dataModel);

            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            try
            {
                var item =
                    await _appDbContext
                        .tblProduct.AsNoTracking()
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

        public async Task<ProductListRespModel> GetProductListAsync()
        {
            try
            {
                var lstProduct = await _appDbContext
                    .tblProduct.AsNoTracking()
                    .OrderByDescending(x => x.Id)
                    .ToListAsync();
                var lst = lstProduct.Select(x => x.ChangeProductModel()).ToList();
                var responseModel = new ProductListRespModel() { lstProduct = lst };

                return responseModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> UpdateProductAsync(ProductReqModel requestModel, int Id)
        {
            try
            {
                var item =
                    await _appDbContext
                        .tblProduct.AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == Id)
                    ?? throw new Exception("No data found.");

                if (!string.IsNullOrEmpty(requestModel.Name))
                {
                    item.Name = requestModel.Name;
                }

                if (requestModel.Price != default && requestModel.Price != 0)
                {
                    item.Price = requestModel.Price;
                }

                _appDbContext.Entry(item).State = EntityState.Modified;

                return await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using ShoppingCart.DbService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public static class ChangeModel
    {
        public static CartItemModel Change(this TblCartItem dataModel)
        {
            return new CartItemModel
            {
                Id= dataModel.Id,
                ProductId= dataModel.ProductId,
                Quantity = dataModel.Quantity,
                UserId = dataModel.UserId,
                UserName=dataModel.UserName,
                ProductName = dataModel.ProductName
            };
        }
    }
}

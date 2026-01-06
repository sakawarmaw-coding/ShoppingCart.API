using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.DbService.Entities
{
    public class TblUser
    {
        public int Id { get; set; }
        public string UserName { get; set; } = default!;
        public string LoginName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}

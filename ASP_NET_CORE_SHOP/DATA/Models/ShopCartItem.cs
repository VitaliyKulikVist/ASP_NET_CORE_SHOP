using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_SHOP.DATA.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Car car { get; set; }
        public int price { get; set; }
        public string shopCardId { get; set; }

    }
}

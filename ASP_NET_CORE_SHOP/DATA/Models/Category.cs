using System.Collections.Generic;

namespace ASP_NET_CORE_SHOP.DATA.Models
{
	public class Category
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Descirption { set; get; }
        public ICollection<Car> Cars { set; get; }
    }
}

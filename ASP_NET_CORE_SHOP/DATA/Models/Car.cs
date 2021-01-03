namespace ASP_NET_CORE_SHOP.DATA.Models
{
	public class Car
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string ShortDescription { set; get; }
        public string LongDescription { set; get; }
        public string Image { set; get; }
        public decimal Price { set; get; }
        public bool IsFavourite { set; get; }
        public int Available { set; get; }
        public int CategoryId { set; get; }
        public Category Category { set; get; }
    }
}

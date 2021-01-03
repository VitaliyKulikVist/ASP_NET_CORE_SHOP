using ASP_NET_CORE_SHOP.DATA.Interfaces;
using ASP_NET_CORE_SHOP.DATA.Models;
using System.Collections.Generic;

namespace ASP_NET_CORE_SHOP.DATA.Moks
{
	public class MockCategory : ICarsCategory
	{
		private static List<Category> _categories = new List<Category>
		{
			new Category
			{
				Name="Електро мобілі",
				Descirption="Приводяться в рух, за допомогою електричного струму"
			},
			new Category
			{
				Name="Бензинові автомобілі",
				Descirption="Приводяться в рух, за допомогою бензину"
			},
			new Category
			{
				Name="Дизельні автомобілі",
				Descirption="Приводяться в рух, за допомогою Дизельного палива"
			},
			new Category
			{
				Name="Бензини водородного синтезу",
				Descirption="Приводяться в рух, за допомогою електролітичних конвекцій з подальшим видобутком водороду"
			}
		};

		public IEnumerable<Category> GetAllCategories() =>
			_categories;
	}
}

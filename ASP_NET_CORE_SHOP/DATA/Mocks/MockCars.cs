using ASP_NET_CORE_SHOP.DATA.Interfaces;
using ASP_NET_CORE_SHOP.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP_NET_CORE_SHOP.DATA.Moks
{
	public class MockCars : IAllCars
	{
		private readonly ICarsCategory _carsCategory;
		private static List<Car> _cars = new List<Car>
		{
			new Car
			{
				Name = "Tesla Модел S",
				ShortDescription = "Білий автомобіль Tesla",
				LongDescription = "Швидкий з середнім запасом ходу",
				Image = "https://atlanticexpress.com.ua/wp-content/uploads/2020/08/tesla_model_s_p100d.jpg",
				Price = 45000,
				IsFavourite = true,
				Available = 20
			},
			new Car
			{
				Name = "Cybertruck",
				ShortDescription = "Футуристично виглядаючий автомобіль",
				LongDescription = "Геометрично правильний автомобіль для дивування прохожих",
				Image = "https://m.dw.com/image/51362527_101.jpg",
				Price = 50000,
				IsFavourite = true,
				Available = 30
            },
			new Car
			{
				Name = "BMW X7",
				ShortDescription = "Громіздкий автомобіль на дизельному палеві",
				LongDescription = "Великий 4х4 кросовер для їзди по бездоріжжю з вмістимим багажником",
				Image = "https://www.bmw.ua/content/dam/bmw/common/all-models/x-series/x7/2018/Inspire/bmw-x7-inspire-radiating-presence-01.jpg",
				Price = 10000,
				IsFavourite = true,
				Available = 30
            }
		};

		public MockCars(ICarsCategory carsCategory)
		{
			_carsCategory = carsCategory
				?? throw new ArgumentNullException(nameof(carsCategory));
		}

		public IEnumerable<Car> GetAllCars()
		{
			var category = _carsCategory.GetAllCategories().FirstOrDefault();

			return _cars.Select(c =>
			{
				c.Category = category;

				return c;
			}).ToList();
		}

		public IEnumerable<Car> GetVafouriteCars()
		{
			var category = _carsCategory.GetAllCategories().FirstOrDefault();

			return _cars.Where(c => c.IsFavourite)
				.Select(c =>
				{
					c.Category = category;

					return c;
				}).ToList();
		}

		public Car GetCarById(int carId)
		{
			var result =  _cars.FirstOrDefault(c => c.Id == carId);

			result.Category = _carsCategory.GetAllCategories().FirstOrDefault();

			return result;
		}
	}
}

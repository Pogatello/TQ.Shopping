using System.Collections.Generic;
using TQ.Shopping.Discounts;
using TQ.Shopping.Loggers;
using TQ.Shopping.TotalSum;

namespace TQ.Shopping.Tests.TestData
{
	public static class GenericTestData
	{
		#region Public Methods

		public static ShoppingCart InizializeEmptyShoppingCart()
		{
			return new ShoppingCart
				(
					InizializeDiscountCalculator(),
					new TotalSumCalculator(),
					new ShoppingCartConsoleLogger()
				);
		}

		public static Article GetArticleMilk()
		{
			return new Article
				(
					"Milk",
					"2",
					1.15m
				);
		}

		public static Article GetArticleButter()
		{
			return new Article
				(
					"Butter",
					"1",
					0.80m
				);
		}

		public static Article GetArticleBread()
		{
			return new Article
				(
					"Bread",
					"3",
					1m
				);
		}

		#endregion

		#region Private Methods

		private static DiscountCalculator InizializeDiscountCalculator()
		{
			return new DiscountCalculator
				(
					new List<IDiscount>
					{
						new ComboDiscount
						(
							"2",
							3,
							true
						),
						new PercentageDiscount
						(
							"1",
							2,
							"3",
							50m
						)
					}
				);
		}

		#endregion
	}
}

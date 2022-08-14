using FluentAssertions;
using System.Collections.Generic;
using TQ.Shopping.Tests.TestData;
using Xunit;

namespace TQ.Shopping.Tests
{
	public class ShoppingCartShould
	{
		#region Tests

		[Fact]
		public void CalculateCorrectTotal_When_NoDiscountsAreApplied()
		{
			#region Arrange

			var cart = GenericTestData.InizializeEmptyShoppingCart();
			cart.AddArticle(GenericTestData.GetArticleBread());
			cart.AddArticle(GenericTestData.GetArticleButter());
			cart.AddArticle(GenericTestData.GetArticleMilk());

			#endregion

			#region Act & Assert

			cart.Total.Should().Be(2.95m);

			#endregion
		}

		[Fact]
		public void CalculateCorrectTotal_When_PercentageDiscountIsApplied()
		{
			#region Arrange

			var cart = GenericTestData.InizializeEmptyShoppingCart();
			cart.AddArticle(GenericTestData.GetArticleBread());
			cart.AddArticle(GenericTestData.GetArticleBread());
			cart.AddArticle(GenericTestData.GetArticleButter());
			cart.AddArticle(GenericTestData.GetArticleButter());

			#endregion

			#region Act & Assert

			cart.Total.Should().Be(3.10m);

			#endregion
		}

		[Fact]
		public void CalculateCorrectTotal_When_ComboDiscountIsApplied()
		{
			#region Arrange

			var cart = GenericTestData.InizializeEmptyShoppingCart();
			cart.AddArticle(GenericTestData.GetArticleMilk());
			cart.AddArticle(GenericTestData.GetArticleMilk());
			cart.AddArticle(GenericTestData.GetArticleMilk());
			cart.AddArticle(GenericTestData.GetArticleMilk());

			#endregion

			#region Act & Assert

			cart.Total.Should().Be(3.45m);

			#endregion
		}

		[Fact]
		public void CalculateCorrectTotal_When_BothPercentageAndComboDiscountAreApplied()
		{
			#region Arrange

			var cart = GenericTestData.InizializeEmptyShoppingCart();
			cart.AddArticle(GenericTestData.GetArticleButter());
			cart.AddArticle(GenericTestData.GetArticleButter());
			cart.AddArticle(GenericTestData.GetArticleBread());
			cart.AddArticle(GenericTestData.GetArticleMilk());
			cart.AddArticle(GenericTestData.GetArticleMilk());
			cart.AddArticle(GenericTestData.GetArticleMilk());
			cart.AddArticle(GenericTestData.GetArticleMilk());
			cart.AddArticle(GenericTestData.GetArticleMilk());
			cart.AddArticle(GenericTestData.GetArticleMilk());
			cart.AddArticle(GenericTestData.GetArticleMilk());
			cart.AddArticle(GenericTestData.GetArticleMilk());

			#endregion

			#region Act & Assert

			cart.Total.Should().Be(9m);

			#endregion
		}

		#endregion
	}
}

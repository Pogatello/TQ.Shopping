namespace TQ.Shopping.Discounts
{
	public class PercentageDiscount : IDiscount
	{
		#region Properties

		public string ArticleCode { get; private set; }

		public int NumberOfRequiredArticles { get; private set; }

		public string DiscountedArticleCode  { get; private set; }

		public decimal DiscountPercentage { get; private set; }

		#endregion

		#region Constructors

		public PercentageDiscount(string articleCode, int numberOfRequiredArticles, string discountedArticleCode, decimal discountPercentage)
		{
			ArticleCode = articleCode;
			NumberOfRequiredArticles = numberOfRequiredArticles;
			DiscountedArticleCode = discountedArticleCode;
			DiscountPercentage = discountPercentage;
		}

		#endregion

		#region IDiscount

		public bool IsApplicable(ShoppingCart cart)
		{
			if (cart?.Articles != null && cart.Articles.Any())
			{
				if (cart.Articles.Count(x => x.Code == ArticleCode) >= NumberOfRequiredArticles
					&& cart.Articles.Any(x=>x.Code == DiscountedArticleCode))
				{
					return true;
				}
			}

			return false;
		}

		public void Apply(ShoppingCart cart)
		{
			//Should be changed a bit, could lead to a loss of discounts, for now it is first discount that comes that one is applied.
			//Depends on the business rules if they allow multiple discounts or not (or one discount per article), or even discount priority
			var articleFromCart = cart.Articles.LastOrDefault(x => x.Code == DiscountedArticleCode && !x.IsDiscountApplied());

			if (articleFromCart != null)
			{
				articleFromCart.SetDiscount(DiscountPercentage);
			}
		}

		#endregion
	}
}

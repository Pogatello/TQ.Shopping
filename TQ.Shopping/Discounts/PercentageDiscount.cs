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
			//Should be changed a bit, possible problem is that discount will be always applied to last article
			//so it will lead to a loss of discounts if that article by article code is eligible for more than one discount
			//Depends on the business rules if they allow multiple discounts or not (or one discount per article - priority?)
			var articleFromCart = cart.Articles.LastOrDefault(x => x.Code == DiscountedArticleCode);

			if (articleFromCart != null)
			{
				articleFromCart.SetDiscount(DiscountPercentage);
			}
		}

		#endregion
	}
}

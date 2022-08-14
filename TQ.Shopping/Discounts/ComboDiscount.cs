namespace TQ.Shopping.Discounts
{
	public class ComboDiscount : IDiscount
	{
		#region Fields

		private readonly decimal DiscountPercentage;

		#endregion

		#region Properties

		public string ArticleCode { get; private set; }

		public int NumberOfRequiredArticles { get; private set; }

		public bool IsRepeatableMultipleTimes { get; private set; }

		#endregion

		#region Constructors

		public ComboDiscount(string articleCode, int numberOfRequiredArticles, bool isRepeatableMultipleTimes)
		{
			ArticleCode = articleCode;
			NumberOfRequiredArticles = numberOfRequiredArticles;
			IsRepeatableMultipleTimes = isRepeatableMultipleTimes;

			DiscountPercentage = 100;
		}

		#endregion

		#region IDiscount

		public bool IsApplicable(ShoppingCart cart)
		{
			if(cart?.Articles != null && cart.Articles.Any())
			{
				if(cart.Articles.Count(x => x.Code == ArticleCode) > NumberOfRequiredArticles)
				{
					return true;
				}
			}

			return false;
		}

		public void Apply(ShoppingCart cart)
		{
			var articlesFromCart = cart.Articles.Where(x => x.Code == ArticleCode);
			if (articlesFromCart != null && articlesFromCart.Any())
			{
				if (IsRepeatableMultipleTimes)
				{
					for(int i = NumberOfRequiredArticles; i < articlesFromCart.Count(); i+=NumberOfRequiredArticles+1)
					{
						articlesFromCart.ElementAt(i).SetDiscount(DiscountPercentage);
					}
				}
				else
				{
					articlesFromCart.ElementAt(NumberOfRequiredArticles).SetDiscount(DiscountPercentage);
				}
			}
		}

		#endregion
	}
}

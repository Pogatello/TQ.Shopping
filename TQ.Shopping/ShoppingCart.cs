using TQ.Shopping.Loggers;
using TQ.Shopping.TotalSum;

namespace TQ.Shopping
{
	public class ShoppingCart
	{
		#region Fields

		//Could be behing a facade..
		private readonly IDiscountCalculator _discountCalculator;
		private readonly ITotalSumCalculator _totalSumCalculator;
		private readonly IShoppingCartLogger _logger;

		#endregion

		#region Properties

		public decimal Total { get => CalculateTotal(); }

		public ICollection<Article> Articles { get; private set; }

		#endregion

		#region Constructors

		public ShoppingCart(IDiscountCalculator discountCalculator, ITotalSumCalculator totalSumCalculator, IShoppingCartLogger logger)
		{
			Articles = new List<Article>();

			_discountCalculator = discountCalculator;
			_totalSumCalculator = totalSumCalculator;
			_logger = logger;	
		}

		#endregion

		#region Public Methods

		public void AddArticle(Article article)
		{
			Articles.Add(article);
			/* Could use ApplyDiscounts(method located in CalculateTotal()) here to have responsive shopping cart
			 * Reset discounts method also needed in real application because multiple calls to ApplyDiscounts will aplly same discount more than once
			 */
		}

		#endregion

		#region Private Methods

		private decimal CalculateTotal()
		{
			ApplyDiscounts();// more info in AddArticle method

			var totalSum = _totalSumCalculator.CalculateSum(this);
			_logger.LogShoppingCartContents(this, totalSum);

			return totalSum;
		}

		private void ApplyDiscounts()
		{
			_discountCalculator.ApplyAllDiscounts(this);
		}

		#endregion
	}
}

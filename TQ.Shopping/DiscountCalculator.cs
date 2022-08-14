using TQ.Shopping.Discounts;

namespace TQ.Shopping
{
	public class DiscountCalculator : IDiscountCalculator
	{
		#region Fields

		private readonly IEnumerable<IDiscount> _discounts;

		#endregion

		#region Constructors

		public DiscountCalculator(IEnumerable<IDiscount> discounts)
		{
			//Usually would grab all discounts from a DiscountRepository(database), so they could be changed in some backoffice application
			_discounts = discounts;
		}

		#endregion

		#region IDiscountCalculator

		public void ApplyAllDiscounts(ShoppingCart cart)
		{
			if(cart?.Articles != null && cart.Articles.Any())
			{
				foreach(var discount in _discounts)
				{
					if (discount.IsApplicable(cart))
					{
						discount.Apply(cart);
					}
				}
			}
		}

		#endregion
	}
}

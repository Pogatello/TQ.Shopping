namespace TQ.Shopping.Discounts.Calculators
{
	public interface IDiscountCalculator
	{
		void ApplyAllDiscounts(ShoppingCart cart);
	}
}

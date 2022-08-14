namespace TQ.Shopping
{
	public interface IDiscountCalculator
	{
		void ApplyAllDiscounts(ShoppingCart cart);
	}
}

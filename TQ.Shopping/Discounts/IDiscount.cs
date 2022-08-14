namespace TQ.Shopping.Discounts
{
	public interface IDiscount
	{
		bool IsApplicable(ShoppingCart cart);

		void Apply(ShoppingCart cart);
	}
}

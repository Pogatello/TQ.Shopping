namespace TQ.Shopping.Loggers
{
	public interface IShoppingCartLogger
	{
		void LogShoppingCartContents(ShoppingCart cart, decimal totalSum);
	}
}

using System.Diagnostics;
using TQ.Shopping.Loggers.Helpers;

namespace TQ.Shopping.Loggers
{
	public class ShoppingCartConsoleLogger : IShoppingCartLogger
	{
		public void LogShoppingCartContents(ShoppingCart cart, decimal totalSum)
		{
			var formattedMessage = ShoppingCartLogHelper.BeautifyText(cart, totalSum);
			Debug.WriteLine(formattedMessage); // for easier testing
			Console.WriteLine(formattedMessage);
		}
	}
}

using System.Text;

namespace TQ.Shopping.Loggers.Helpers
{
	public static class ShoppingCartLogHelper
	{
		public static string BeautifyText(ShoppingCart cart, decimal totalSum)
		{
			var sb = new StringBuilder();

			sb.AppendLine();
			sb.AppendLine($"Shopping cart total sum requested at: {DateTime.Now}");
			sb.AppendLine("Articles in a cart:");

			foreach(var art in cart.Articles)
			{
				sb.AppendLine(art.Name);
				sb.AppendLine($"Price: {art.Price}	Discount: {art.Discount}%	TotalPrice: {art.TotalPrice}");
				sb.AppendLine("--------------------");
			}

			sb.AppendLine($"TOTAL SUM: {totalSum}$");

			return sb.ToString();
		}
	}
}

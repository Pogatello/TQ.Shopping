namespace TQ.Shopping.TotalSum
{
	public class TotalSumCalculator : ITotalSumCalculator
	{
		#region ITotalSumCalculator

		public decimal CalculateSum(ShoppingCart cart)
		{
			return cart.Articles.Sum(x => x.TotalPrice);
		}

		#endregion
	}
}

namespace TQ.Shopping
{
	public class Article
	{
		#region Properties

		public string Name { get; private set; }

		public string Code { get; private set; }

		public decimal Price { get; private set; }

		public decimal Discount { get; private set; }

		public decimal TotalPrice { get => GetTotalPrice();}

		#endregion

		#region Constructors

		public Article(string name, string code, decimal price)
		{
			Name = name;
			Code = code;
			Price = price;
			Discount = 0;
		}

		#endregion

		#region Public Methods

		public void SetDiscount(decimal discount)
		{
			Discount = discount;
		}

		#endregion

		#region Private Methods

		private decimal GetTotalPrice()
		{
			var discountedPricePart = Price * (Discount / 100);

			return Price - discountedPricePart;
		}

		#endregion
	}
}

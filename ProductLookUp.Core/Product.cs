using System;

namespace ProductLookup.Core
{
	public class Product
	{
		public string Name {
			get;
			set;
		}

		public string SKU {
			get;
			set;
		}

		public string Description {
			get;
			set;
		}

		public float Price {
			get;
			set;
		}

		public Product ()
		{
		}

		public static Product GetTestProduct()
		{
			return new Product () {
				Name = "Bread",
				SKU = "1234567890",
				Description = "Meat delivery system.",
				Price = 1.64F
			};
		}
	}
}


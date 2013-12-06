using System;

namespace ProductLookup.Core
{
	public static class ProductLookupAPI
	{
		public static Product GetByName(string name)
		{
			Product item = Product.GetTestProduct ();
			if (item.Name.ToLower() != name.ToLower())
				return null;

			return item;
		}

		public static Product GetBySKU(string sku)
		{
			Product item = Product.GetTestProduct ();
			if (item.SKU.ToLower() != sku.ToLower())
				return null;

			return item;
		}

	}
}


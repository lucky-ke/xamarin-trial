using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProductLookup.Core;

namespace XandroidApp
{
	[Activity (Label = "ProductDisplay")]			
	public class ProductDisplayActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			string searchText = Intent.GetStringExtra(MainActivity.ITEM_FIND);
			Product product = ProductLookupAPI.GetByName (searchText);
			if (product == null)
				product = ProductLookupAPI.GetBySKU (searchText);

			if (product == null) {
				Intent intent = new Intent ();
				intent.PutExtra(MainActivity.ERROR_MESSAGE, "Product not found!");
				SetResult (Result.Canceled, intent);
				Finish ();
				return;
			}

			SetContentView (Resource.Layout.ProductDisplay);
			TextView name = FindViewById<TextView> (Resource.Id.name_content);
			name.Text = product.Name;

			TextView price = FindViewById<TextView> (Resource.Id.price_content);
			price.Text = product.Price.ToString();

			TextView sku = FindViewById<TextView> (Resource.Id.sku_content);
			sku.Text = product.SKU;

			TextView description = FindViewById<TextView> (Resource.Id.description_content);
			description.Text = product.Description;
		}
	}
}


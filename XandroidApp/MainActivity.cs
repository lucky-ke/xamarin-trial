using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace XandroidApp
{
	[Activity (Label = "XandroidApp", MainLauncher = true)]
	public class MainActivity : Activity
	{
		public const string ITEM_FIND = "ItemLookup.ItemFind";
		public const string ERROR_MESSAGE = "ItemLookup.ErrorMessage";
		public const int FIND_ITEM_REQUEST_CODE = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//Set Button For Search Tap
			Button findButton = FindViewById<Button>(Resource.Id.find_button);

			findButton.Click += (o, e) => {
				FindItem();
			};
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent response)
		{
			if (requestCode == FIND_ITEM_REQUEST_CODE && resultCode == Result.Canceled) {
				string errorText = response.GetStringExtra (MainActivity.ERROR_MESSAGE);
				TextView error = FindViewById<TextView> (Resource.Id.error_content);
				error.Text = errorText == null ? "" : errorText;
			}
		}

		public void FindItem()
		{
			Intent intent = new Intent (this, typeof(ProductDisplayActivity));
			EditText searchText = FindViewById<EditText>(Resource.Id.edit_product);
			intent.PutExtra(ITEM_FIND, searchText.EditableText.ToString ());
			StartActivityForResult (intent, FIND_ITEM_REQUEST_CODE); 
		}
	}
}



using System;

using Xamarin.Forms;
using System.Collections.Generic;

//mobileFirst


namespace Plenty
{
	public class Offers : ContentPage
	{
		public static String mfpClient = null;
		public static List<OffersModel> offers = null;

		//dummy offers
		public async void setOffers() {
			offers = new List<OffersModel> {
				new OffersModel ("Snack Nuts", "For offers refer", "NUTS.jpg"),
				new OffersModel ("potatoes", "For offers refer", "Potatoes.jpg"),
				new OffersModel ("Snack Nuts", "For offers refer", "NUTS.jpg"),
				new OffersModel ("potatoes", "For offers refer", "Potatoes.jpg"),
				new OffersModel ("Snack Nuts", "For offers refer", "NUTS.jpg"),
				new OffersModel ("potatoes", "For offers refer", "Potatoes.jpg"),
				new OffersModel ("Snack Nuts", "For offers refer", "NUTS.jpg"),
				new OffersModel ("potatoes", "For offers refer", "Potatoes.jpg"),
				new OffersModel ("Snack Nuts", "For offers refer", "NUTS.jpg"),
				new OffersModel ("potatoes", "For offers refer", "Potatoes.jpg"),
			};
		}
       
		public Offers ()
		{

			//commented out dummy offers
			//setOffers ();

			Title = "Offers";
			Icon = "Offers.png";


			// Create a data template from the type ImageCell
			var cell = new DataTemplate (typeof(ImageCell));

			cell.SetBinding (TextCell.TextProperty, "Name");
			cell.SetBinding (TextCell.DetailProperty,"Description");
			cell.SetBinding (ImageCell.ImageSourceProperty, "Image");

			ListView listView = new ListView {
				ItemsSource = offers,
				ItemTemplate = cell // Set the ImageCell to the item template for the listview
			};

			// Push the list view down below the status bar on iOS.
			this.Padding = new Thickness (10, Device.OnPlatform (20, 0, 0), 10, 5);

			// Set the content for the page.
			this.Content = new StackLayout {
				Children = {
					//header,
					listView
				}
			};

		}
	}
}



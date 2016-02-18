using System;
using Xamarin.Forms;
using System.Collections.Generic;
using LoginModule;
namespace Plenty
{

	public class MenuItem
	{
		public string Title { get; set; }

		public string IconSource { get; set; }

		public Type TargetType { get; set; }
	}

	public class MenuListView : ListView
	{
		public MenuListView ()
		{
			List<MenuItem> data = new MenuListData ();

			ItemsSource = data;
			VerticalOptions = LayoutOptions.FillAndExpand;
			BackgroundColor = Color.Transparent;

			var cell = new DataTemplate (typeof(ImageCell));
			cell.SetBinding (TextCell.TextProperty, "Title");
			cell.SetBinding (ImageCell.ImageSourceProperty, "IconSource");

			ItemTemplate = cell;
		}
	}

	public class MenuListData : List<MenuItem>
	{
		public MenuListData ()
		{
			this.Add (new MenuItem () { 
				Title = "Home", 
				IconSource = "Offers.png", 
				TargetType = typeof(MainPageCS)
			});

			this.Add (new MenuItem () { 
				Title = "PlentyID", 
				IconSource = "Offers.png", 
				TargetType = typeof(DetailPage)
			});

		}
	}

}


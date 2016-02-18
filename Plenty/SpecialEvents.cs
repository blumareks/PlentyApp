using System;

using Xamarin.Forms;
using System.Collections.Generic;

using LoginModule;
namespace Plenty
{
	public class SpecialEvents : ContentPage
	{

		public static List<EventsModel> events = null;

		public SpecialEvents ()
		{
			Icon = "Events.png";
			Title = "Special Events";

			/*
			Content = new TableView { 
				Intent = TableIntent.Menu,
				Root = new TableRoot () { 

					new TableSection ("Meeting Times") {
						new ImageCell () {
							Text = "Monday 3:20 PM - 4:15 PM",
							Detail = "Fleming 24-106",
							ImageSource = new FileImageSource () { File = "Recommendations.png" }
						},
						new ImageCell () {
							Text = "Monday 3:20 PM - 4:15 PM",
							Detail = "Fleming 24-106",
							ImageSource = new FileImageSource () { File = "Recommendations.png" }
						},
						new ImageCell () {
							Text = "Monday 3:20 PM - 4:15 PM",
							Detail = "Fleming 24-106",
							ImageSource = new FileImageSource () { File = "Recommendations.png" }
						}
					}
				}
			};
			*/

			// Create a data template from the type ImageCell
			var cell = new DataTemplate (typeof(ImageCell));

			cell.SetBinding (TextCell.TextProperty, "Name");
			cell.SetBinding (TextCell.DetailProperty,"Description");
			cell.SetBinding (ImageCell.ImageSourceProperty, "Image");

			ListView listView = new ListView {
				ItemsSource = events,
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

			//To Enable Navigation on Navigation Bar
			/*ToolbarItems.Add(new ToolbarItem {
				Name = "Launch",
				Order = ToolbarItemOrder.Primary,
				Command = new Command(() => Navigation.PushAsync(new LoginPage(App.Current)))
			});*/
		}
	}
}



using System;

using Xamarin.Forms;

namespace Plenty
{
	public class MainPageCS : TabbedPage
	{
		
		public MainPageCS ()
		{
			//Title in Navigation Bar for Offers
			var navigationPage = new NavigationPage (new Offers ());
			navigationPage.Title = "Offers";
			navigationPage.Icon = "Offers.png";

			//Title in Navigation Bar for Events
			var navigationEventsPage = new NavigationPage (new SpecialEvents());
			navigationEventsPage.Title = "Special Events";
			navigationEventsPage.Icon = "Events.png";

			//Title in Navigation Bar for Recommendations
			var navigationRecommendationsPage = new NavigationPage (new Recommendations());
			navigationRecommendationsPage.Title = "Recommendations";
			navigationRecommendationsPage.Icon = "Recommendations.png";

			Children.Add (navigationPage);
			Children.Add (navigationEventsPage);
			Children.Add (navigationRecommendationsPage);

		}
	}
}



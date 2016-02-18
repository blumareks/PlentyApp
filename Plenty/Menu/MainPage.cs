using System;
using Xamarin.Forms;

namespace Plenty
{
	public class MainPage : MasterDetailPage
	{
		public MainPage ()
		{
			var menuPage = new MenuPage ();

			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo (e.SelectedItem as MenuItem);

			Master = menuPage;

			Detail = new DetailPage();
		}

		void NavigateTo (MenuItem menu)
		{
			Page displayPage = (Page)Activator.CreateInstance (menu.TargetType);

			Detail = displayPage;

			IsPresented = false;
		}
	}
}


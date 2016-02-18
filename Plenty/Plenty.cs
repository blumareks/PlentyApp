using System;

using Xamarin.Forms;
using LoginModule;

namespace Plenty
{
	public class App : Application,ILoginManager
	{
		public static App Current;

		public static string plentyID {
			get;
			set;
		}

		public App ()
		{	
			Current = this;


			var isLoggedIn = Properties.ContainsKey("IsLoggedIn")?(bool)Properties ["IsLoggedIn"]:false;

			// we remember if they're logged in, and only display the login page if they're not
			if (isLoggedIn)
				MainPage = new MainPage();//Plenty.MainPageCS ();
			else
				MainPage = new LoginModalPage (this);
		}

		public void ShowMainPage ()
		{	
			MainPage = new MainPage ();
		}
		public void ShowLoginPage ()
		{	
			MainPage = new LoginModalPage (this);
		}

		public void Logout ()
		{
			Properties ["IsLoggedIn"] = false; // only gets set to 'true' on the LoginPage
			MainPage = new LoginModalPage (this);
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}


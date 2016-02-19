using System;
using Xamarin.Forms;
using Plenty;

namespace LoginModule
{
	public class LoginPage : ContentPage
	{
		public Entry plentyID; //, password;

		public LoginPage ()
		{
			
		}

		public LoginPage (ILoginManager ilm)
		{
			var button = new Button { Text = "Signup" };
			button.Clicked += (sender, e) => {
				if (String.IsNullOrEmpty(plentyID.Text))// || String.IsNullOrEmpty(password.Text))
				{
					DisplayAlert("Validation Error", "Username and Password are required", "Re-try");
				} else {
					// REMEMBER LOGIN STATUS!
					App.Current.Properties["IsLoggedIn"] = true;
					ilm.ShowMainPage();
				}
			};
			/*var create = new Button { Text = "Create Account" };
			create.Clicked += (sender, e) => {
				MessagingCenter.Send<ContentPage> (this, "Create");
			};*/

			plentyID = new Entry { Text = "" };
			//password = new Entry { Text = "" };
			Content = new StackLayout {
				Padding = new Thickness (10, 40, 10, 10),
				Children = {
					new Label { Text = "Signup", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) }, 
					new Label { Text = "Plenty ID" },
					plentyID,
					//new Label { Text = "Password" },
					//password,
					button, 
					//create
				}
			};
		}
	}
}


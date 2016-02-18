using System;

using Xamarin.Forms;

namespace Plenty
{
	public class Recommendations : ContentPage
	{
		public Recommendations ()
		{
			
			Title = "Recommendations";
			Icon = "Recommendations.png";

			Content =new StackLayout { 
				Children = {
					
					new Label { 
						Text = "Hello Recommendations",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand 
					}

				}
			};
		}
	}
}



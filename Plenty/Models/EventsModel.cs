using System;

using Xamarin.Forms;

namespace Plenty
{
	public class EventsModel 
	{
		public EventsModel (string name, string description, string image)
		{
			this.Name = name;
			this.Description = description;
			//this.Image = image;
			//removing dash "-" http://stackoverflow.com/questions/7411438/remove-characters-from-c-sharp-string
			this.Image = String.Join("", image.Split('-'));
		}

		public string Name { private set; get; }

		public string Description { private set; get; }

		public string Image { private set; get; }
	}
}



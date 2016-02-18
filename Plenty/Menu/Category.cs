using System;
using Xamarin.Forms;

namespace Plenty
{
	public class Category
	{
		public string Name {
			get;
			set;
		}

		public Func<ContentPage> PageFn {
			get;
			set;
		}

		public Category (string name, Func<ContentPage> pageFn)
		{
			Name = name;
			PageFn = pageFn;
		}
	}
}


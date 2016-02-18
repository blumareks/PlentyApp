using System;

namespace LoginModule
{
	public interface ILoginManager {
		void ShowMainPage ();
		void ShowLoginPage();
		void Logout();
	}
}


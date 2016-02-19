using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plenty;
using System.Collections.Generic;

using Worklight;
using Worklight.Xamarin.Android;
using System.Threading.Tasks;
using System.Text;
using System.Json;

namespace Plenty.Droid
{
	public class CustomChallengeHandler : ChallengeHandler
	{

		public LoginFormInfo LoginFormParameters{get;  set;}
		private bool authSuccess = false;
		private bool isAdapterAuth = false;
		private bool shouldSubmitLoginForm = false;

		public CustomChallengeHandler(string realm)
		{
			this.Realm = realm;
		}

		public override LoginFormInfo GetLoginFormParameters()
		{
			return LoginFormParameters;
		}
		//string realm;
		public string Realm;
		public override string GetRealm()
		{
			return Realm;
		}

		public override bool ShouldSubmitSuccess ()
		{
			return authSuccess;
		}
		public override bool ShouldSubmitAdapterAuthentication()
		{
			return isAdapterAuth;
		}

		public override bool ShouldSubmitLoginForm ()
		{
			return shouldSubmitLoginForm;
		}

		public override void HandleChallenge(WorklightResponse challenge)
		{
			LoginModule.LoginPage loginPage=new LoginModule.LoginPage(); 

			Console.WriteLine ("We were challenged.. so we are handling it");
			Dictionary<String,String > parms = new Dictionary<String, String> (); 
			parms.Add ("j_username", "admin");
			parms.Add ("j_password", loginPage.plentyID.Text); //"admin"); 
			Console.WriteLine (loginPage.plentyID.Text);
			LoginFormParameters = new LoginFormInfo ("j_security_check", parms, null, 30000, "post");
			shouldSubmitLoginForm = true;

		}

		public override bool IsCustomResponse(WorklightResponse response)
		{
			Console.WriteLine (response.ResponseText.ToString ());
			Console.WriteLine ("Determining if its a custom response");
			if (response == null || response.ResponseText==null || !(response.ResponseText.Contains("j_security_check")))
			{
				Console.WriteLine ("not a custom response");
				return false;
			}
			Console.WriteLine ("true, it is a custom response");
			return true;

		}

		public override void OnSuccess(WorklightResponse challenge)
		{
			Console.WriteLine("Challenge handler success");

		}

		public override void OnFailure(WorklightResponse response)
		{
			Console.WriteLine("Challenge handler failure");
		}
	}
}


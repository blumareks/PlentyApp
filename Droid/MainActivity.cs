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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;




namespace Plenty.Droid
{
	[Activity (Label = "Plenty.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		//STEP 1: update URL_STRONGLOOP according to the VM IP by calling ipconfig command
		public static string URL_STRONGLOOP = "http://192.168.0.118:3000/api/"; 
		//STEP 2: update Plenty.Droid/Assets/wlclient.properties
		//        - the field wlServerHost to point to the VM IP
		public static IWorklightClient mfpClient = null;
		WorklightLogger logger = null;
		public bool isInitialCall = true;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new App ());

			//initializing MobileFirst Foundation 
			setOffers ();
		}
	

		//mfp initialilzing environment
		public async void setOffers ()
		{
			var isConnected = false;

			//mobileFirst client
			if (mfpClient == null) {
				mfpClient = WorklightClient.CreateInstance (this);
			}

			System.Console.WriteLine ("MFP before connect");

			//getting connection
			WorklightResponse task1 = await mfpClient.Connect ();
			if (task1.Success) {
				Console.WriteLine ("connected to MFP");

				logger = mfpClient.Logger("Xamarin: MainActivity.cs");

				logger.Info("connection from Android Plenty app established");
				//write to the server the connection status
				mfpClient.Analytics.Log("Connect response : " + task1.Success);
				isConnected = true;
			} else {
				Console.WriteLine ("connection failed");
			} 

			//accessing protected feedAdapter
			if (isConnected) {

				//adding challengehandler
				string appRealm = "PlentyAppRealm";
				ChallengeHandler customCH = new CustomChallengeHandler (appRealm);
				mfpClient.RegisterChallengeHandler (customCH);
				System.Console.WriteLine ("MFP before adapter");

				WorklightProcedureInvocationData invocationData = 
					new WorklightProcedureInvocationData (
						"FeedAdapter", "getFeed", new object[] { "" });
				
				WorklightResponse task3 = await mfpClient.InvokeProcedure (invocationData);
				if (task3.Success) {
					isInitialCall = false;
					Console.WriteLine ("adapter connected");
					Console.WriteLine (task3.ResponseText.ToString ());

					logger.Info("FeedAdapter Accessed from Android Plenty app");
					//write to the server the connection status
					mfpClient.Analytics.Log("FeedAdapter response : " + task3.Success);
				} else {
					Console.WriteLine ("adapter failed");
					Console.WriteLine (task3.ResponseJSON.ToString ());

					logger.Error("FeedAdapter FAILED from Android Plenty app");
					//write to the server the connection status
					mfpClient.Analytics.Log("FeedAdapter response : " + task3.ResponseText);
				}
			
			}
			//end of protected feedAdapter


			task1 = await mfpClient.Connect ();

			if (task1.Success) {
				Console.WriteLine ("connected to MFP");
				isConnected = true;
			} else {
				Console.WriteLine ("connection failed");
			} 


			//ACCESSING STRONGLOOP for Offers
			if (isConnected) {
				System.Console.WriteLine ("MFP before SL url");

				//calling protected adapter (strongloop)
				/*WorklightProcedureInvocationData invocationData = 
					new WorklightProcedureInvocationData (
						"SLAdapter", "getOffers", new object[] { "" });

				WorklightResponse task2 = await mfpClient.InvokeProcedure (invocationData);
				*/

				//calling protected url (strongLoop)
				WorklightResourceRequest resourceRequest = mfpClient.ResourceRequest (
					new Uri (URL_STRONGLOOP+"Offers"), "GET");
				WorklightResponse task2 = await resourceRequest.Send ();


				if (task2.Success) {
					Console.WriteLine ("strongloop url connected");
					Console.WriteLine (task2.ResponseText.ToString ());

					logger.Info("Strongloop Accessed/Offers from Android Plenty app");
					//write to the server the connection status
					mfpClient.Analytics.Log("Strongloop response : " + task2.Success);

					Plenty.Offers.offers = new List<OffersModel> {};
					JsonArray jsonArray = new JsonArray (task2.ResponseText);

					Console.WriteLine (jsonArray.Count);
					var myObjectList = 
						(List<Offer>)
						JsonConvert.DeserializeObject (task2.ResponseText, typeof(List<Offer>));
					foreach (Offer offer in myObjectList) {
						/*
						Console.WriteLine (offer.offername);
						Console.WriteLine (offer.offerdescription);
						Console.WriteLine (offer.offerpicture);
						*/

						Plenty.Offers.offers.Add (new OffersModel (
							offer.offername,
							offer.offerdescription,
							offer.offerpicture));

					}
				} else {
					Console.WriteLine ("strongloop url failed");
					Console.WriteLine (task2.ResponseText.ToString ());

					logger.Error("Strongloop FAILED on Offers from Android Plenty app");
					//write to the server the connection status
					mfpClient.Analytics.Log("Strongloop response : " + task2.ResponseText);

					//dummy offers
					Plenty.Offers.offers = new List<OffersModel> {
						new OffersModel ("potatoes", "For offers refer", "Potatoes.jpg"),
						new OffersModel (
							"Buy one get one free on salted nuts for the big game!",
							"This offer entitles you to a free can of salted nuts for every can you purchase.  Limit 4.",
							"offers/asparagus.jpg"),
					};
				}
			} else {
				Console.WriteLine ("connection for SL failed");
				//dummy offers
				logger.Error("Strongloop FAILED even on Connection to MFP? while on Offers from Android Plenty app");
				//write to the server the connection status
				mfpClient.Analytics.Log("FeedAdapter response : " + task1.ResponseText);

				Plenty.Offers.offers = new List<OffersModel> {
					new OffersModel (
						"Buy one get one free on salted nuts for the big game!",
						"This offer entitles you to a free can of salted nuts for every can you purchase.  Limit 4.",
						"NUTS.jpg"),
				};
			} //end Strongloops for Offers
				

			task1 = await mfpClient.Connect ();

			if (task1.Success) {
				Console.WriteLine ("connected to MFP");
				isConnected = true;
			} else {
				Console.WriteLine ("connection failed");
			} 


			//ACCESSING STRONGLOOP for Events
			if (isConnected) {
				System.Console.WriteLine ("MFP before SL url");
				//calling protected url (strongLoop)
				WorklightResourceRequest resourceRequest = mfpClient.ResourceRequest (
					new Uri (URL_STRONGLOOP+"Events"), "GET");
				WorklightResponse task4 = await resourceRequest.Send ();


				if (task4.Success) {
					Console.WriteLine ("strongloop url connected");
					Console.WriteLine (task4.ResponseText.ToString ());
					logger.Info("Strongloop Accessed/Events from Android Plenty app");
					//write to the server the connection status
					mfpClient.Analytics.Log("Strongloop response : " + task4.Success);

					Plenty.SpecialEvents.events = new List<EventsModel> {};

					JsonArray jsonArray = new JsonArray (task4.ResponseText);

					Console.WriteLine (jsonArray.Count);
					var myObjectList = 
						(List<Event>) JsonConvert.DeserializeObject (task4.ResponseText, typeof(List<Event>));
					foreach (Event myevent in myObjectList) {
						Plenty.SpecialEvents.events.Add (new EventsModel (
							myevent.offername,
							myevent.offerdescription,
							myevent.offerpicture));

					}
				} else {
					Console.WriteLine ("strongloop url failed");
					Console.WriteLine (task4.ResponseText.ToString ());
					logger.Error("Strongloop FAILED on Events from Android Plenty app");
					//write to the server the connection status
					mfpClient.Analytics.Log("Strongloop response : " + task4.ResponseText);
					//dummy events
					Plenty.SpecialEvents.events = new List<EventsModel> {
						new EventsModel (
							"Growler Fill-Up",
							"Fill up your growler from a selection of local craft beers!",
							"events/fillyourgrowler.jpg"),
					};
				}
			} else {
				Console.WriteLine ("connection for SL failed");
				logger.Error("Strongloop FAILED even on Connection to MFP? while on Offers from Android Plenty app");
				//write to the server the connection status
				mfpClient.Analytics.Log("FeedAdapter response : " + task1.ResponseText);
				//dummy offers
				Plenty.Offers.offers = new List<OffersModel> {
					new OffersModel (
						"Buy one get one free on salted nuts for the big game!",
						"This offer entitles you to a free can of salted nuts for every can you purchase.  Limit 4.",
						"NUTS.jpg"),
				};
			}
		}

	}

	//helper class for the Json deserialization automation
	public class Offer
	{
		[JsonProperty ("id")]
		public int id { get; set; }

		[JsonProperty ("loyaltyid")]
		public int loyaltyid { get; set; }

		[JsonProperty ("offerdescription")]
		public string offerdescription { get; set; }

		[JsonProperty ("offername")]
		public string offername { get; set; }

		[JsonProperty ("offerpicture")]
		public string offerpicture { get; set; }

	}

	//JSON deserialization for Events
	//{"id":1,"eventdescription":"Fill up your growler from a selection of local craft beers!","eventname":"Growler Fill-Up","eventpicture":"events/fill-your-growler.jpg","loyaltyid":123},{"id":2,"eventdescription":"Come and learn new tips from our grilling experts!","eventname":"Grilling secrets revealed!","eventpicture":"events/grilling-secrets.jpg","loyaltyid":123},{"id":3,"eventdescription":"This event will feature many organic farmers from your area with specialty items to sample.","eventname":"Meet your local organic growers","eventpicture":"events/meet-organic-grower.jpg","loyaltyid":124},{"id":4,"eventdescription":"Taste the latest varietals in this special wine lovers event.","eventname":"Wine Tasting","eventpicture":"events/wine-tasting.jpg","loyaltyid":124},{"id":5,"eventdescription":"Are you a klutz in the kitchen?  Well no more, this class will teach you how to cook a four-course meal!","eventname":"Learn to cook!","eventpicture":"events/learn-to-cook.jpg","loyaltyid":125},{"id":6,"eventdescription":

	public class Event
	{
		[JsonProperty ("id")]
		public int id { get; set; }

		[JsonProperty ("loyaltyid")]
		public int loyaltyid { get; set; }

		[JsonProperty ("eventdescription")]
		public string offerdescription { get; set; }

		[JsonProperty ("eventname")]
		public string offername { get; set; }

		[JsonProperty ("eventpicture")]
		public string offerpicture { get; set; }

	}
}

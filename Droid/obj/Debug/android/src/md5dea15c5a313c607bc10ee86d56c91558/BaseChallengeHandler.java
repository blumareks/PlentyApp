package md5dea15c5a313c607bc10ee86d56c91558;


public abstract class BaseChallengeHandler
	extends com.worklight.wlclient.api.challengehandler.BaseChallengeHandler
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Worklight.Xamarin.Android.BaseChallengeHandler, Worklight.Xamarin.Android, Version=7.1.0.1, Culture=neutral, PublicKeyToken=null", BaseChallengeHandler.class, __md_methods);
	}


	public BaseChallengeHandler (java.lang.String p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == BaseChallengeHandler.class)
			mono.android.TypeManager.Activate ("Worklight.Xamarin.Android.BaseChallengeHandler, Worklight.Xamarin.Android, Version=7.1.0.1, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

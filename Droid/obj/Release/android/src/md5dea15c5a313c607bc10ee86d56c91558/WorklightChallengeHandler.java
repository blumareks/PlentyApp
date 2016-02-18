package md5dea15c5a313c607bc10ee86d56c91558;


public class WorklightChallengeHandler
	extends com.worklight.wlclient.api.challengehandler.ChallengeHandler
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_handleChallenge:(Lcom/worklight/wlclient/api/WLResponse;)V:GetHandleChallenge_Ljava_lang_Object_Handler\n" +
			"n_isCustomResponse:(Lcom/worklight/wlclient/api/WLResponse;)Z:GetIsCustomResponse_Lcom_worklight_wlclient_api_WLResponse_Handler\n" +
			"n_onSuccess:(Lcom/worklight/wlclient/api/WLResponse;)V:GetOnSuccess_Lcom_worklight_wlclient_api_WLResponse_Handler\n" +
			"n_onFailure:(Lcom/worklight/wlclient/api/WLFailResponse;)V:GetOnFailure_Lcom_worklight_wlclient_api_WLFailResponse_Handler\n" +
			"";
		mono.android.Runtime.register ("Worklight.Xamarin.Android.WorklightChallengeHandler, Worklight.Xamarin.Android, Version=7.1.0.1, Culture=neutral, PublicKeyToken=null", WorklightChallengeHandler.class, __md_methods);
	}


	public WorklightChallengeHandler (java.lang.String p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == WorklightChallengeHandler.class)
			mono.android.TypeManager.Activate ("Worklight.Xamarin.Android.WorklightChallengeHandler, Worklight.Xamarin.Android, Version=7.1.0.1, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}


	public void handleChallenge (com.worklight.wlclient.api.WLResponse p0)
	{
		n_handleChallenge (p0);
	}

	private native void n_handleChallenge (com.worklight.wlclient.api.WLResponse p0);


	public boolean isCustomResponse (com.worklight.wlclient.api.WLResponse p0)
	{
		return n_isCustomResponse (p0);
	}

	private native boolean n_isCustomResponse (com.worklight.wlclient.api.WLResponse p0);


	public void onSuccess (com.worklight.wlclient.api.WLResponse p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (com.worklight.wlclient.api.WLResponse p0);


	public void onFailure (com.worklight.wlclient.api.WLFailResponse p0)
	{
		n_onFailure (p0);
	}

	private native void n_onFailure (com.worklight.wlclient.api.WLFailResponse p0);

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

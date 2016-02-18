package md5dea15c5a313c607bc10ee86d56c91558;


public class NotificationListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.worklight.wlclient.api.WLNotificationListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onMessage:(Ljava/lang/String;Ljava/lang/String;)V:GetOnMessage_Ljava_lang_String_Ljava_lang_String_Handler:Worklight.Android.IWLNotificationListenerInvoker, Worklight.Android\n" +
			"";
		mono.android.Runtime.register ("Worklight.Xamarin.Android.NotificationListener, Worklight.Xamarin.Android, Version=7.1.0.1, Culture=neutral, PublicKeyToken=null", NotificationListener.class, __md_methods);
	}


	public NotificationListener () throws java.lang.Throwable
	{
		super ();
		if (getClass () == NotificationListener.class)
			mono.android.TypeManager.Activate ("Worklight.Xamarin.Android.NotificationListener, Worklight.Xamarin.Android, Version=7.1.0.1, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onMessage (java.lang.String p0, java.lang.String p1)
	{
		n_onMessage (p0, p1);
	}

	private native void n_onMessage (java.lang.String p0, java.lang.String p1);

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

package mono.com.worklight.wlclient.api;


public class WLOnReadyToSubscribeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.worklight.wlclient.api.WLOnReadyToSubscribeListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onReadyToSubscribe:()V:GetOnReadyToSubscribeHandler:Worklight.Android.IWLOnReadyToSubscribeListenerInvoker, Worklight.Android\n" +
			"";
		mono.android.Runtime.register ("Worklight.Android.IWLOnReadyToSubscribeListenerImplementor, Worklight.Android, Version=7.1.0.1, Culture=neutral, PublicKeyToken=null", WLOnReadyToSubscribeListenerImplementor.class, __md_methods);
	}


	public WLOnReadyToSubscribeListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == WLOnReadyToSubscribeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Worklight.Android.IWLOnReadyToSubscribeListenerImplementor, Worklight.Android, Version=7.1.0.1, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onReadyToSubscribe ()
	{
		n_onReadyToSubscribe ();
	}

	private native void n_onReadyToSubscribe ();

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

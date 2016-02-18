package mono.com.worklight.wlclient.api;


public class WLHttpResponseListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.worklight.wlclient.api.WLHttpResponseListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onFailure:(Lorg/apache/http/HttpResponse;Ljava/lang/Exception;)V:GetOnFailure_Lorg_apache_http_HttpResponse_Ljava_lang_Exception_Handler:Worklight.Android.IWLHttpResponseListenerInvoker, Worklight.Android\n" +
			"n_onSuccess:(Lorg/apache/http/HttpResponse;)V:GetOnSuccess_Lorg_apache_http_HttpResponse_Handler:Worklight.Android.IWLHttpResponseListenerInvoker, Worklight.Android\n" +
			"";
		mono.android.Runtime.register ("Worklight.Android.IWLHttpResponseListenerImplementor, Worklight.Android, Version=7.1.0.1, Culture=neutral, PublicKeyToken=null", WLHttpResponseListenerImplementor.class, __md_methods);
	}


	public WLHttpResponseListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == WLHttpResponseListenerImplementor.class)
			mono.android.TypeManager.Activate ("Worklight.Android.IWLHttpResponseListenerImplementor, Worklight.Android, Version=7.1.0.1, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onFailure (org.apache.http.HttpResponse p0, java.lang.Exception p1)
	{
		n_onFailure (p0, p1);
	}

	private native void n_onFailure (org.apache.http.HttpResponse p0, java.lang.Exception p1);


	public void onSuccess (org.apache.http.HttpResponse p0)
	{
		n_onSuccess (p0);
	}

	private native void n_onSuccess (org.apache.http.HttpResponse p0);

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

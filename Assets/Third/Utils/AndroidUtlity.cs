using UnityEngine;

class AndroidUtlity
{
	public static void Show_Dialog_Wireless_Settings()
	{
		#if !UNITY_EDITOR

		using (AndroidJavaClass unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
		{
			using (AndroidJavaObject currentActivityObject = unityClass.GetStatic<AndroidJavaObject>("currentActivity"))
			{
				using (AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent", "android.settings.WIFI_SETTINGS"))
				{
					currentActivityObject.Call("startActivity", intentObject);
				}
			}
		}

		#endif
	}

	public static string Get_GAID()
    {
		#if UNITY_ANDROID && !UNITY_EDITOR

		AndroidJavaClass unitydefault = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

		AndroidJavaObject activity = unitydefault.GetStatic<AndroidJavaObject>("currentActivity");

		AndroidJavaObject context = activity.Call<AndroidJavaObject>("getApplicationContext");

        using AndroidJavaClass javaClass = new AndroidJavaClass("ru.andlancer.gaid.JGaid");

        if (javaClass != null)
        {
            string _gaid = javaClass.CallStatic<string>("get", context);

            if (_gaid.Contains(" "))
            {
                _gaid.Replace(' ', '_');
            }

            return _gaid;
        }
        else
        {
            return "[NONE_GAID]";
        }

		#else

		return "[NONE_GAID]";

		#endif
	}
}

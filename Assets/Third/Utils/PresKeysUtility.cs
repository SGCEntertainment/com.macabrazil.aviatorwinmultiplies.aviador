using UnityEngine;

class PresKeysUtility
{
    const string bot_dts_responce_key = "bot_dts_responce";
    const string config_key = "config_key";
    const string am_device_id_key = "am_device_id_key";

    public static void SetBotTDSResponce(string bot_tds_responce)
    {
        PlayerPrefs.SetString(bot_dts_responce_key, bot_tds_responce);
        PlayerPrefs.Save();
    }

    public static string GetBotTDSResponce()
    {
        return PlayerPrefs.HasKey(bot_dts_responce_key) ? PlayerPrefs.GetString(bot_dts_responce_key) : null;
    }

    public static void SetConfig(string config)
    {
        PlayerPrefs.SetString(config_key, config);
        PlayerPrefs.Save();
    }

    public static string GetConfig()
    {
        return PlayerPrefs.HasKey(config_key) ? PlayerPrefs.GetString(config_key) : null;
    }

    public static void SetAMDeviceID(string am_device_id)
    {
        PlayerPrefs.SetString(am_device_id_key, am_device_id);
        PlayerPrefs.Save();
    }

    public static string GetAMDeviceID()
    {
        return PlayerPrefs.HasKey(am_device_id_key) ? PlayerPrefs.GetString(am_device_id_key) : "AM_DEVICE_UNKNOW";
    }
}

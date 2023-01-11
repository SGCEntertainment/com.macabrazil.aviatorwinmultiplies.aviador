using System;
using UnityEngine;
using System.Collections;

public class AppMetrica : MonoBehaviour
{
    public const string VERSION = "5.0.0";

    private static bool s_isInitialized;
    private bool _actualPauseStatus;

    private static IYandexAppMetrica s_metrica;
    private static readonly object s_syncRoot = new UnityEngine.Object();

    public static IYandexAppMetrica Instance
    {
        get
        {
            if (s_metrica == null)
            {
                lock (s_syncRoot)
                {
                    #if UNITY_ANDROID
                    if (s_metrica == null && Application.platform == RuntimePlatform.Android)
                    {
                        s_metrica = new YandexAppMetricaAndroid();
                    }
                    #endif
                    if (s_metrica == null)
                    {
                        s_metrica = new YandexAppMetricaDummy();
                    }
                }
            }

            return s_metrica;
        }
    }
    IEnumerator Start()
    {
        while (MainLogic.Instance.IsWaitAppmetrica)
        {
            yield return null;
        }

        if (!s_isInitialized)
        {
            s_isInitialized = true;
            SetupMetrica();
        }

        Instance.ResumeSession();
    }

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (MainLogic.Instance.noNetwork || MainLogic.Instance.container == null)
        {
            return;
        }

        if (_actualPauseStatus != pauseStatus)
        {
            _actualPauseStatus = pauseStatus;
            if (pauseStatus)
            {
                Instance.PauseSession();
            }
            else
            {
                Instance.ResumeSession();
            }
        }
    }

    private void SetupMetrica()
    {
        YandexAppMetricaConfig configuration = new YandexAppMetricaConfig(MainLogic.Instance.container.beforeData.appmetricaAppId_prop)
        {
            SessionTimeout = 10,
            Logs = false,
            HandleFirstActivationAsUpdate = false,
            StatisticsSending = true,
            LocationTracking = false
        };

        Instance.ActivateWithConfiguration(configuration);

        Action<string, YandexAppMetricaRequestDeviceIDError?> action;
        action = GetId;

        Instance.RequestAppMetricaDeviceID(action);
        Instance.SetUserProfileID(AndroidUtlity.Get_GAID());

        AppMetricaPush.Instance.Initialize();
    }

    void GetId(string AM_DEVICE_ID, YandexAppMetricaRequestDeviceIDError? errors)
    {
        MainLogic.Instance.AM_DEVICE_IDGet = true;
        PresKeysUtility.SetAMDeviceID(AM_DEVICE_ID);
    }

    private static void HandleLog(string condition, string stackTrace, LogType type)
    {
        if (type == LogType.Exception)
        {
            Instance.ReportErrorFromLogCallback(condition, stackTrace);
        }
    }
}

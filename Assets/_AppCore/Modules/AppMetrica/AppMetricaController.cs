#if APCR_APPMETRICA

using System.Collections.Generic;
using UnityEngine;
//using Newtonsoft.Json;

namespace AppCore
{
    public enum CustomAdPlacement
    {
        none,
        skip_level,
        get_skin,
        increase_money_reward,
        get_farm_struct,
        get_time_reward
    }

    public enum CustomAdType
    {
        rewarded,
        interstitial,
    }

    public enum ResultType
    {
        success,
        not_available,
        error,
        started,
        watched,
        clicked,
        canceled
    }

    public enum LevelResult
    {
        win,
        lose
    }

    public enum UnlockedType
    {
        default_free,
        ad,
        money,
    }

    public class AppMetricaController : MonoBehaviour
    {
        public static AppMetricaController Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void SendAdAvailableEvent(CustomAdType customAdType, CustomAdPlacement customAdPlacement, ResultType resultType)
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("ad_type", customAdType.ToString());
            keyValuePairs.Add("placement", customAdPlacement.ToString());
            keyValuePairs.Add("result", resultType.ToString());
            keyValuePairs.Add("connection", NetworkManager.Instance.HasConnection ? 1 : 0);

            AppMetrica.Instance.ReportEvent("video_ads_available", keyValuePairs);

            //Debug.Log("***APP_METRICA video_ads_available: " + JsonConvert.SerializeObject(keyValuePairs));
        }

        public void SendVideoAdsStartedEvent(CustomAdType customAdType, CustomAdPlacement customAdPlacement, ResultType resultType)
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("ad_type", customAdType.ToString());
            keyValuePairs.Add("placement", customAdPlacement.ToString());
            keyValuePairs.Add("result", resultType.ToString());
            keyValuePairs.Add("connection", NetworkManager.Instance.HasConnection ? 1 : 0);

            AppMetrica.Instance.ReportEvent("video_ads_started", keyValuePairs);

            //Debug.Log("***APP_METRICA video_ads_started: " + JsonConvert.SerializeObject(keyValuePairs));
        }

        public void SendVideoAdWatchedEvent(CustomAdType customAdType, CustomAdPlacement customAdPlacement, ResultType resultType)
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("ad_type", customAdType.ToString());
            keyValuePairs.Add("placement", customAdPlacement.ToString());
            keyValuePairs.Add("result", resultType.ToString());
            keyValuePairs.Add("connection", NetworkManager.Instance.HasConnection ? 1 : 0);

            AppMetrica.Instance.ReportEvent("video_ads_watch", keyValuePairs);

            //Debug.Log("***APP_METRICA video_ads_watch: " + JsonConvert.SerializeObject(keyValuePairs));
        }

        public void LevelStartEvent(int levelNumber, string levelName, int levelCount, int levelLoopCount, bool isRandomizedLevel)
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("level_number", levelNumber);
            keyValuePairs.Add("level_name", levelName);
            keyValuePairs.Add("level_count", levelCount);
            keyValuePairs.Add("level_loop", levelLoopCount);
            keyValuePairs.Add("level_random", isRandomizedLevel);

            AppMetrica.Instance.ReportEvent("level_start", keyValuePairs);
            AppMetrica.Instance.SendEventsBuffer();

            //Debug.Log("***APP_METRICA level_start: " + JsonConvert.SerializeObject(keyValuePairs));
        }

        public void LevelFinishEvent(int levelNumber, string levelName, int levelCount, int levelLoopCount, bool isRandomizedLevel, LevelResult levelResult, int timePassed)
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("level_number", levelNumber);
            keyValuePairs.Add("level_name", levelName);
            keyValuePairs.Add("level_count", levelCount);
            keyValuePairs.Add("level_loop", levelLoopCount);
            keyValuePairs.Add("level_random", isRandomizedLevel);
            keyValuePairs.Add("result", levelResult.ToString());
            keyValuePairs.Add("time", timePassed);

            AppMetrica.Instance.ReportEvent("level_finish", keyValuePairs);
            AppMetrica.Instance.SendEventsBuffer();

            //Debug.Log("***APP_METRICA level_finish: " + JsonConvert.SerializeObject(keyValuePairs));
        }

        public void SkinUnlocked(string skinName, UnlockedType unlockedType)
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            keyValuePairs.Add("skin_type", "man");
            keyValuePairs.Add("skin_name", skinName);
            keyValuePairs.Add("unlock_type", unlockedType.ToString());

            AppMetrica.Instance.ReportEvent("skin_unlock", keyValuePairs);

            //Debug.Log("***APP_METRICA skin_unlock: " + JsonConvert.SerializeObject(keyValuePairs));
        }
    }
}
#endif
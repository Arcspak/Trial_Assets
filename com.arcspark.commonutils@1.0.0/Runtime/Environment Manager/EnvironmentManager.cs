using UnityEngine;

namespace Arcspark.CommonUtils
{
    /// <summary>
    /// A game environment manager.
    /// </summary>
    public class EnvironmentManager
    {
        /// <summary>
        /// Callback delegate used when langType value changes.
        /// </summary>
        /// <param name="langType">Changed language type.</param>
        public delegate void OnLanguageChange(LangType langType);

        /// <summary>
        /// Enumeration of all platforms.
        /// </summary>
        public enum PlatformType
        {
            NONE,
            EDITOR,
            WIN32,
            WIN64,
            MAC,
            ANDROID,
            IOS
        }

        /// <summary>
        /// Enumeration of all deliverys.
        /// </summary>
        public enum DeliveryType
        {
            NONE,
            DEV,
            QA,
            STAGE,
            PROD
        }

        /// <summary>
        /// Enumeration of all languages.
        /// </summary>
        public enum LangType
        {
            NONE,
            ZH_CN,
            EN
        }

        private void Init()
        {
#if UNITY_EDITOR
            platformEnvir = PlatformType.EDITOR;
#elif UNITY_STANDALONE_WIN && UNITY_64
            platformEnvir = PlatformType.WIN64;
#elif UNITY_STANDALONE_WIN
            platformEnvir = PlatformType.WIN32;
#elif UNITY_STANDALONE_OSX
            platformEnvir = PlatformType.MAC;
#elif UNITY_ANDROID
            platformEnvir = PlatformType.ANDROID;
#elif UNITY_IOS
            platformEnvir = PlatformType.IOS;
#endif

            // The delivery dcripting define symbols will be defined in player settings
#if DEV
            deliveryEnvir = DeliveryType.DEV;
#elif QA
            deliveryEnvir = DeliveryType.QA;
#elif STAGE
            deliveryEnvir = DeliveryType.STAGE;
#elif PROD
            deliveryEnvir = DeliveryType.PROD;
#endif

            switch (Application.systemLanguage)
            {
                case SystemLanguage.Chinese:
                    langEnvir = LangType.ZH_CN;
                    break;
                case SystemLanguage.English:
                    langEnvir = LangType.EN;
                    break;
                default:
                    langEnvir = LangType.ZH_CN;
                    break;
            }
        }

        private EnvironmentManager() {}

        /// <summary>
        /// Gets the current runtime platform type.
        /// </summary>
        public PlatformType PlatformEnvir
        {
            get => platformEnvir;
        }

        /// <summary>
        /// Gets the current delivery type.
        /// </summary>
        public DeliveryType DeliveryEnvir
        {
            get => deliveryEnvir;
        }

        /// <summary>
        /// Gets the current language type.
        /// </summary>
        public LangType LangEnvir
        {
            get => langEnvir;
            set
            {
                langEnvir = value;
                if (OnLanguageChangeCallback != null)
                {
                    OnLanguageChangeCallback(langEnvir);
                }
            }
        }

        /// <summary>
        /// Access interface of singleton design pattern object.
        /// </summary>
        public static EnvironmentManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syslock)
                    {
                        if (instance == null)
                        {
                            instance = new EnvironmentManager();
                            instance.Init();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// This event is triggered to notify when the language type is changed.
        /// </summary>
        public event OnLanguageChange OnLanguageChangeCallback;
        private PlatformType platformEnvir;
        private DeliveryType deliveryEnvir;
        private LangType langEnvir;

        private static EnvironmentManager instance;
        private static readonly object syslock = new object();
    }
}
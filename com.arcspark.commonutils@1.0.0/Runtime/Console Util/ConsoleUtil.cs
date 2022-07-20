using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Arcspark.CommonUtils
{
    /// <summary>
    /// Console log extension tool.
    /// </summary>
	public class ConsoleUtil
	{
        /// <summary>
        /// Save log to local.
        /// </summary>
        public static void Save()
        {
            FileUtil.Instance.SetFile("runtime.log", Log);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void ConsoleExtensionInit()
		{
			Application.logMessageReceived +=
				(condition, stackTrace, type) =>
				{
					string message =
						string.Format(
							"Local Time: {0}\nContent: {1}\nStack Trace:\n{2}\n",
							DateTime.Now.ToLocalTime().ToString(),
							condition,
							stackTrace
						);
                    CacheLog(message, type);
				};
		}

        private static void CacheLog(string message, LogType logType)
        {
            List<LogType> catches = EnabledLogTypes();

            if (catches.Contains(logType))
                log.Append(message);
        }

        private static List<LogType> EnabledLogTypes()
        {
            EnvironmentManager.DeliveryType deliveryType = EnvironmentManager.Instance.DeliveryEnvir;
            List<LogType> catches;

            if (deliveryType == EnvironmentManager.DeliveryType.PROD)
            {
                catches = new List<LogType>{
                    LogType.Warning,
                    LogType.Error
                };
            }
            else
            {
                catches = new List<LogType>{
                    LogType.Log,
                    LogType.Assert,
                    LogType.Exception,
                    LogType.Warning,
                    LogType.Error,
                };
            }
            return catches;
        }

        /// <summary>
        /// Get cached log.
        /// </summary>
        public static string Log
        { 
            get => log.ToString();
        }

        private static StringBuilder log = new StringBuilder();
    }
}
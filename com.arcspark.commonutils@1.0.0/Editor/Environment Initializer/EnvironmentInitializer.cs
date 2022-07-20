using Arcspark.CommonUtils;
using System;
using UnityEditor;
using UnityEditor.Build;

namespace Arcspark.Editor
{
    public class EnvironmentInitializer
    {
        [InitializeOnLoadMethod]
        private static void EnvironmentInit()
        {
            Symbols symbols = new Symbols(NamedBuildTarget.Standalone);

            bool needSetDelivery = true;
            foreach (EnvironmentManager.DeliveryType deliveryType in Enum.GetValues(typeof(EnvironmentManager.DeliveryType)))
            {
                if (symbols.Contains(deliveryType.ToString()))
                {
                    needSetDelivery = false;
                    break;
                }
            }

            if (needSetDelivery)
            {
                symbols.Add(initDeliveryType.ToString());
                symbols.Save();
            }
        }

        private const EnvironmentManager.DeliveryType initDeliveryType = EnvironmentManager.DeliveryType.DEV;
    }
}
using Arcspark.CommonUtils;
using UnityEngine;

namespace Arcspark.Sample.EnvironmentManagerSample
{
    public class Sample : MonoBehaviour
    {
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            Debug.Log(EnvironmentManager.Instance.PlatformEnvir);
            Debug.Log(EnvironmentManager.Instance.DeliveryEnvir);
            Debug.Log(EnvironmentManager.Instance.LangEnvir);
        }
    }
}
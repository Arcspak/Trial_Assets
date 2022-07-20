using Arcspark.CommonUtils;
using UnityEngine;

namespace Arcspark.Sample.VSDebugSample
{
    public class Sample : MonoBehaviour
    {
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            Debug.LogWarning("Test.");
            ConsoleUtil.Save();
        }
    }
}
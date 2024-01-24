using UnityEngine;

namespace Manager
{
    public class GlobalUpdateManager : MonoBehaviour
    {
        private void Update()
        {
            for (int i = 0; i < MonoCache.AllUpdate.Count; i++) MonoCache.AllUpdate[i].Tick();
        }
    }
}

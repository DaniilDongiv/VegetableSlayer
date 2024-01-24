using Configs;
using UnityEngine;

namespace Systems
{
    public class KillSystem : MonoBehaviour
    {
        private ConfigKillModel _configKillModel;

        private void Awake()
        {
            _configKillModel = new ConfigKillModel();
        }

        public void Kill(int murders)
        {
            _configKillModel.Kill += 1;
        }

        public int ReturnNumberKills()
        {
            return _configKillModel.Kill;
        }
    }
}

using Systems;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        private KillSystem _killSystem;
        private int _maxKills;

        private void Awake()
        {
            _killSystem = FindObjectOfType<KillSystem>();
            if (PlayerPrefs.HasKey("MaxKills"))
            {
                _maxKills = PlayerPrefs.GetInt("MaxKills");
            }
        }
        
        public void UpdateMaxKills()
        {
            var newKills = _killSystem.ReturnNumberKills();
            if (newKills > _maxKills)
            {
                _maxKills = newKills;
                PlayerPrefs.SetInt("MaxKills", _maxKills);
                PlayerPrefs.Save();
            }
        }

        public int GetMaxKill()
        {
            return _maxKills;
        }
    }
}
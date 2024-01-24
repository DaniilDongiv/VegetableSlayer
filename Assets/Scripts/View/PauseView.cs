using Systems;
using TMPro;
using UnityEngine;

namespace View
{
    public class PauseView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _killText;
        
        private KillSystem _killSystem;
        
        private void Awake()
        {
            _killSystem = FindObjectOfType<KillSystem>();
        }
        
        public void UpdateKills()
        {
            _killText.text = "Kill: " + _killSystem.ReturnNumberKills();
        }
    }
}

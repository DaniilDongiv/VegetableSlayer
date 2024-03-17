using Systems;
using TMPro;
using UnityEngine;

namespace View
{
    public class KillView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _killText;

        private KillSystem _killSystem;

        private void Awake()
        {
            _killSystem = FindObjectOfType<KillSystem>();
        }
        
        public void Update()
        {
            _killText.text = "SCORE: " + _killSystem.ReturnNumberKills();
        }
    }
}

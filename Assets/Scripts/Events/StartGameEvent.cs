using TMPro;
using UnityEngine;

namespace Events
{
    public class StartGameEvent : MonoCache
    {
        [SerializeField]
        private TextMeshProUGUI _clickBeginGame;

        private Event _event;
        
        private void Awake()
        {
            Time.timeScale = 0f;
        }
        
        public override void OnTick()
        {
            if (Input.GetMouseButton(0))
            {
                Time.timeScale = 1;
                _clickBeginGame.enabled = false;
                Destroy(this);
            }

        }
    }
}

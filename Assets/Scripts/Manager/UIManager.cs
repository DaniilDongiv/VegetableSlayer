using Client;
using Controller;
using UnityEngine;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private HealthBar _healthBarPrefabs;

        public void CreateHealthBar(Transform uiElementRoot)
        {
            var healthBar = Instantiate(_healthBarPrefabs, transform);
            healthBar.GetComponent<UIElementPositionController>().Initialize(uiElementRoot);
            healthBar.Initialize(uiElementRoot.GetComponent<HealthController>());
        }
    }
}

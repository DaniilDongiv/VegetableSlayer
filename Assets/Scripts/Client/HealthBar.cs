using Controller;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Slider _healthBar;
        [SerializeField]
        private HealthController _healthController;

        private float _maxHealth;

        public void Initialize(HealthController healthController)
        {
            _healthController = healthController;
            _maxHealth = _healthController.MaxHealth;
            _healthController.TookDamage += SetHealthValue;
            SetHealthValue(_maxHealth);
        }

        private void SetHealthValue(float currentHealth)
        {
            _healthBar.value = currentHealth / _maxHealth;
        }

        private void OnDestroy()
        {
            _healthController.TookDamage -= SetHealthValue;
        }
    }
}

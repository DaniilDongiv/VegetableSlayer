using System;
using UnityEngine;
using UnityEngine.Events;

namespace Controller
{
    public class HealthController : MonoBehaviour
    {
        public Action<float> TookDamage;
        public UnityEvent DiedEvent;

        public float MaxHealth => _maxHealth;

        [SerializeField]
        private float _maxHealth;
        private float _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void HealthChange(float value)
        {
            _currentHealth += value;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            TookDamage?.Invoke(_currentHealth);

            if (_currentHealth <=0)
            {
                DiedEvent?.Invoke();
                Destroy(gameObject);
            }
        }
        
    }
}

using System.Collections;
using UnityEngine;

namespace Controller
{
    public class AttackController : MonoBehaviour
    {
        [SerializeField] 
        private Transform _damageZone;
        [SerializeField] 
        private float _damageZoneRadius = 1;
        [SerializeField] 
        private LayerMask _layers;

        private readonly float _standardDamageValue = 5;
        private readonly float _elevatedDamageValue = 10f;
        private float _damageValue = 5;

        public void DealDamage()
        {
            var hitColliders = Physics.OverlapSphere(_damageZone.position, _damageZoneRadius, _layers);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.TryGetComponent(out HealthController player))
                {
                    player.TakeDamage(_damageValue);
                }
            }
        }

        public void StartCoroutineIncreasedDamage()
        {
            StartCoroutine(IncreasedDamage());
        }
        
        private IEnumerator IncreasedDamage()
        {
            _damageValue = _elevatedDamageValue;
            yield return new WaitForSeconds(10f);
            _damageValue = _standardDamageValue;
        }
    }
}

using System.Threading.Tasks;
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

        public async Task ChangingDamage(float temporaryDamage, int time)
        {
            var damage = _damageValue;
            
            _damageValue = temporaryDamage;
            await Task.Delay(time);
            _damageValue = damage;
        }
    }
}

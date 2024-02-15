using System.Collections;
using System.Threading.Tasks;
using DOTween;
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
        
        private DOTweenController _doTweenController;

        public void DealDamage()
        {
            var hitColliders = Physics.OverlapSphere(_damageZone.position, _damageZoneRadius, _layers);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.TryGetComponent(out HealthController player))
                {
                    _doTweenController = FindObjectOfType<DOTweenController>();
                    StartCoroutine(_doTweenController.AttackAnimationTrigger(hitCollider.gameObject));
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

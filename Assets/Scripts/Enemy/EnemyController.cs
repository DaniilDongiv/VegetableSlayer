using System;
using Controller;
using Systems;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyController : MonoCache
    {
        public Action<EnemyController> Enemy;
        
        private GameObject _player;
        private NavMeshAgent _navMeshAgent;
        private KillSystem _killSystem;

        private float _speed;
        private EntityAnimationController _animationController;

        private void Awake()
        {
            _killSystem = FindObjectOfType<KillSystem>();
            _player = GameObject.Find("Player");
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _speed = _navMeshAgent.speed;
            _animationController = GetComponent<EntityAnimationController>();
        }
        
        public override void OnTick()
        {
            transform.LookAt(_player.transform);
            _navMeshAgent?.SetDestination(_player.transform.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                _navMeshAgent.speed = 0f;
                _animationController?.AttackAnimation(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                _navMeshAgent.speed = _speed;
                _animationController?.AttackAnimation(false);
            }
        }
        
        public void Destroy()
        {
            _killSystem.Kill(1);
            Destroy(gameObject);
        }
    }
}

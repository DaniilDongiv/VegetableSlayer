using Systems;
using UnityEngine;
using UnityEngine.AI;
using static TagManager;

namespace Enemy
{
    public class EnemyController : MonoCache
    {
        private GameObject _player;
        private NavMeshAgent _navMeshAgent;
        private KillSystem _killSystem;

        private float _speed;
        private bool _isAttake;

        private Animator _animator;
        private static readonly int Attack = Animator.StringToHash("Attack");

        private void Awake()
        {
            _killSystem = FindObjectOfType<KillSystem>();
            _player = GameObject.Find("Player");
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _speed = _navMeshAgent.speed;
            _animator = GetComponentInChildren<Animator>();
        }
        
        public override void OnTick()
        {
            transform.LookAt(_player.transform);
            _navMeshAgent.SetDestination(_player.transform.position);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _isAttake = true;
                _navMeshAgent.speed = 0f;
                _animator.SetBool(Attack, true);
                //TODO: поменять 
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(PLAYER))
            {
                _isAttake = !_isAttake;
                _navMeshAgent.speed = _speed;
                _animator.SetBool(Attack, false);
            }
        }
        
        public void Destroy()
        {
            _killSystem.Kill(1);
            Destroy(gameObject);
        }
    }
}

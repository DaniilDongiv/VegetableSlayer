using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoCache
    {
        public UnityEvent<Transform> PlayerSpawner;
        public static bool IsAttack = true;

        [SerializeField] private FixedJoystick _joystick;

        private bool _isJump;
        private int _speed = 5;
        private int _speedSlowingDown = 3;
        private int _standardSpeed = 5;
        private Rigidbody _rigidbody;
        private Animator _animator;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponentInChildren<Animator>();
            PlayerSpawner?.Invoke(transform);
        }

        public override void OnTick()
        {
            MovePhone();
            if (Input.GetKeyDown(KeyCode.K))
            {
                AttackTrigger();
            }
        }
        
        public void StartCoroutineSlowingDownSpeed()
        {
            StartCoroutine(SlowingDownSpeedCoroutine());
        }
        
        private IEnumerator SlowingDownSpeedCoroutine()
        {
            _speed = _speedSlowingDown;
            yield return new WaitForSeconds(10f);
            _speed = _standardSpeed;
        }

        private void AttackTrigger()
        {
            if (IsAttack)
            {
                IsAttack = false;
                _animator.SetTrigger("Attack");
            }
        }
        
        private void MovePhone()
        {
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speed, _rigidbody.velocity.y,
                _joystick.Vertical * _speed);
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
                _animator.SetBool("Walk", true);

            }
            else 
                _animator.SetBool("Walk", false);
        }
    }
}

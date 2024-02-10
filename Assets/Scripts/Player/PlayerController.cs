using System.Collections;
using Controller;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoCache, IMoveController, IAttackController
    {
        public UnityEvent<Transform> PlayerSpawner;
        
        private int _speed = 5;
        private int _speedSlowingDown = 3;
        private int _standardSpeed = 5;
        
        private Rigidbody _rigidbody;
        private PlayerAnimationController _animationController;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            PlayerSpawner?.Invoke(transform);
            _animationController = GetComponent<PlayerAnimationController>();
        }

        public override void OnTick()
        {
            
            if (Input.GetKeyDown(KeyCode.K))
            {
                _animationController.AttackAnimation();
            }
            //TODO: в другой коасс
        }
        
        public void StartCoroutineSlowingDownSpeed()
        {
            StartCoroutine(SlowingDownSpeedCoroutine());
            //TODO: поменять
        }
        
        private IEnumerator SlowingDownSpeedCoroutine()
        {
            _speed = _speedSlowingDown;
            yield return new WaitForSeconds(10f);
            _speed = _standardSpeed;
            //TODO: поменять 
        }

        private void AttackTrigger()
        {
            //TODO: поменять
        }

        public void Move(Vector2 inputs)
        {
            _rigidbody.velocity = new Vector3(inputs.y * _speed, _rigidbody.velocity.y,inputs.x * _speed);
            
            if (inputs.y != 0 || inputs.x != 0)
            {
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
                _animationController.MoveAnimation(true);
            }
            else 
                _animationController.MoveAnimation(false);
        }
        
        public void Attack(bool isAttack)
        {
            if (isAttack)
            {
                isAttack = false;
                //TODO: Так же посмотреть код выше
                _animationController.AttackAnimation();
            }
        }
    }
}

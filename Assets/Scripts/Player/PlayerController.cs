using Controller;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour, IMoveController, IAttackController
    {
        public UnityEvent<Transform> PlayerSpawner;
        
        private  int _speed = 5;
        
        private Rigidbody _rigidbody;
        private EntityAnimationController _animationController;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            PlayerSpawner?.Invoke(transform);
            _animationController = GetComponent<EntityAnimationController>();
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
                Attack(false);
                _animationController.AttackAnimation();
            }
        }
    }
}

using UnityEngine;

namespace Controller
{
    public class EntityAnimationController : MonoBehaviour
    {
        private Animator _animator;
        
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Attack = Animator.StringToHash("Attack");

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }

        public void MoveAnimation(bool isMove)
        {
            _animator.SetBool(Walk, isMove);
        }

        public void AttackAnimation()
        {
            _animator.SetTrigger(Attack);
        }

        public void AttackAnimation(bool isAttack)
        {
            _animator.SetBool(Attack, isAttack);
        }
    }
}

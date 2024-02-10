using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
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
}

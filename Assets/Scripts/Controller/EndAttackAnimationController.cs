using System;
using Controller;
using Player;
using UnityEngine;

public class EndAttackAnimationController : MonoBehaviour
{
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
    }

    public void AttackEndAnimation()
    {
        _playerController.Attack(false);
    }
}

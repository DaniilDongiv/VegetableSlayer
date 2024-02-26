using Controller;
using Player;
using UnityEngine;

public class KeyboardAttackInput : MonoCache
{
    private IAttackController _playerController;
        
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public override void OnTick()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _playerController.Attack(true);
        }
    }

    public void Attack()
    {
        _playerController.Attack(true);
    }
}

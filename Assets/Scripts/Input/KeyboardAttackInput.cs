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
        _playerController.Attack(Input.GetKeyDown(KeyCode.K));
    }
}

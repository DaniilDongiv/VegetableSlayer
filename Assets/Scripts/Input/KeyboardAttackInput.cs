using Controller;
using Player;
using UnityEngine;

public class KeyboardAttackInput : MonoCache
{
    private IMoveController _playerController;
        
    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    public override void OnTick()
    {
        
    }
}

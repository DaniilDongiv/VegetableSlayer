using Controller;
using Player;
using UnityEngine;

public class KeyboardMoveInput : MonoCache
    {
        [SerializeField] private FixedJoystick _joystick;
        
        private IMoveController _playerController;
        
        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
        }

        public override void OnTick()
        {
            var inputs = ProcessInput();
            _playerController.Move(inputs);
        }

        private Vector2 ProcessInput()
        {
            float moveHorizontal = _joystick.Horizontal;
            float moveVertical = _joystick.Vertical;

            return new Vector2(moveVertical, moveHorizontal);
        }
        
    }


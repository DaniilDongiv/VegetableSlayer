using System;
using UnityEngine;

namespace Player
{
    public class AnimationControllerPlayer : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }
        
        
    }
}

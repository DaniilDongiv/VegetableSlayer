using UnityEngine;

namespace Controller
{
    public interface IMoveController
    {
        public void Move(Vector2 inputs);
    }

    public interface IAttackController
    {
        public void Attack(bool isAttack);
    }
}

using Player;
using UnityEngine;

namespace Controller
{
    public class AttackClickDuc : MonoBehaviour,IAttackController
    {
        public void AttackEndAnim()
        {
            Attack(true);
         //TODO: исправить ошибку(не работает)   
        }

        public void Attack(bool isAttack)
        {
            isAttack = true;
        }
    }
}

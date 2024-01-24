using Player;
using UnityEngine;

namespace Controller
{
    public class AttackClickDuc : MonoBehaviour
    {
        public void AttackEndAnim()
        {
            PlayerController.IsAttack = true;
        }
    }
}

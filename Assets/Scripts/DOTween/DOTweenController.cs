using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace DOTween
{
    public class DOTweenController : MonoBehaviour
    {
        private Vector3 _objectScale;
        

        private IEnumerator AttackAnimationTrigger()
        {
            transform.DOScale(_objectScale.y-0.1f, 0.3f);
            yield return new WaitForSeconds(0.4f);
            transform.DOScale(_objectScale.y, 0.3f);
        }
    }
}

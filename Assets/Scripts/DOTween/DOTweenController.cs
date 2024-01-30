using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace DOTween
{
    public class DOTweenController : MonoBehaviour
    {
        private Vector3 _objectScale;
        
        public IEnumerator AttackAnimationTrigger(GameObject gameObjectGame)
        {
            gameObjectGame.transform.DOScale(gameObjectGame.transform.localScale.y-0.1f, 0.05f);
            yield return new WaitForSeconds(0.1f);
            gameObjectGame.transform.DOScale(gameObjectGame.transform.localScale.y+0.1f, 0.05f);
        }
    }
}

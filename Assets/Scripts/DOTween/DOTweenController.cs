using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace DOTween
{
    public class DOTweenController : MonoBehaviour
    {
        public IEnumerator AttackAnimationTrigger(GameObject gameObjectGame)
        {
            var localScale = gameObjectGame.transform.localScale;
            
            gameObjectGame.transform.DOScale(localScale.y-0.1f, 0.01f);
            yield return new WaitForSeconds(0.1f);
            gameObjectGame.transform.DOScale(localScale.y, 0.01f);
        }
    }
}

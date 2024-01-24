using System.Collections;
using TMPro;using UnityEngine;

namespace View
{
    public class BonusView : MonoBehaviour
    {
        [SerializeField] private GameObject _bonusValueLabel;

        public void SetBonus(string value)
        {
            var objectText = Instantiate(_bonusValueLabel,transform,false);
            objectText.GetComponent<TextMeshProUGUI>().text = value;
            StartCoroutine(TimerDestroyText(objectText));
        }

        private IEnumerator TimerDestroyText(GameObject gameObject)
        {
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
        }
    }
}

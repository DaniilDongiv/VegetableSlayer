using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace View
{
    public class DataView : MonoBehaviour
    {
        public UnityEvent<int> SaveDiedEvent;

        [SerializeField] private TextMeshProUGUI _maxKill;

        public void UpdateDate(int intData)
        {
            _maxKill.text = intData.ToString();
        }

        public void SavePressed()
        {
            var intData = Convert.ToInt32(_maxKill.text);
        
            SaveDiedEvent.Invoke(intData);
        }
    }
}

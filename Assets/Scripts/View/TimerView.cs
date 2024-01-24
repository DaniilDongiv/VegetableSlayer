using System;
using Configs;
using Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _remainsTime;
        [SerializeField]
        private Slider _slider;
        
        private TimerSystem _timer;
        private ConfigGameTimeModel _configGameTimeModel;

        private void Awake()
        {
            _timer = FindObjectOfType<TimerSystem>();
            _configGameTimeModel = new ConfigGameTimeModel();
            _slider.maxValue = _configGameTimeModel.RemainingTime;
        }
        
        private void Update()
        {
            var time = Convert.ToInt32(_timer.GetRemainsTime());
            _remainsTime.text = "" + time;
            _slider.value = time;
        }
    }
}

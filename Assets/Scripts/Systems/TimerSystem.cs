using Configs;
using UnityEngine;
using UnityEngine.Events;

namespace Systems
{
    public class TimerSystem : MonoBehaviour
    {
        public UnityEvent EndTime;

        private ConfigGameTimeModel _configGameTimeModel;
        private float _gameTime;

        private void Awake()
        {
            _configGameTimeModel = new ConfigGameTimeModel();
        }

        private void FixedUpdate()
        {
            _gameTime += 1 * Time.deltaTime;
            if (_gameTime>=1 && _configGameTimeModel.RemainingTime > 0)
            {
                _configGameTimeModel.RemainingTime -=  1;
                if (_configGameTimeModel.RemainingTime <=0)
                {
                    EndTime?.Invoke();
                }
                _gameTime = 0;
            }
        }

        public float GetRemainsTime()
        {
            return _configGameTimeModel.RemainingTime;
        }

        public ConfigGameTimeModel GetConfigGameTimeModel()
        {
            return _configGameTimeModel;
        }
            
    }
}

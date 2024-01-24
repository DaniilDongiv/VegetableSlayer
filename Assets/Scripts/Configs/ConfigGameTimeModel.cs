using System;

namespace Configs
{
    [Serializable]
    public class ConfigGameTimeModel
    {
        public float RemainingTime
        {
            get => _remainingTime;
            set => _remainingTime = (int)value;
        }

        private int _remainingTime = 180;
    }
}

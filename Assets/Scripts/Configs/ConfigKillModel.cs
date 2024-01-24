using UnityEngine;

namespace Configs
{
    public class ConfigKillModel
    {
        public int Kill
        {
            get => _kill;
            set => _kill = value;
        }

        private int _kill;
    }
}

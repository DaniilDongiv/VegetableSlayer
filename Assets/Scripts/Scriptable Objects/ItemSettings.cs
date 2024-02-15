using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "ItemSettings", menuName = "Scriptable Objects/ItemSettings", order = 50)]
    public class ItemSettings : ScriptableObject
    {
        public string[] Name => _name;
        
        [SerializeField]
        private string[] _name;
    }
}
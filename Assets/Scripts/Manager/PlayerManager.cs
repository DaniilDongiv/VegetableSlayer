using UnityEngine;
using UnityEngine.Events;

namespace Manager
{
    public class PlayerManager : MonoBehaviour
    {
        public UnityEvent<int> UpdateDate;

        private const string INT_DATA_KEY = "IntData";

        public  void Save(int intData)
        {
            PlayerPrefs.SetInt(INT_DATA_KEY, intData);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            PlayerPrefs.HasKey(INT_DATA_KEY);
            var intDate = PlayerPrefs.GetInt(INT_DATA_KEY);
           
           UpdateDate.Invoke(intDate);
        }

        public void Reset()
        {
            PlayerPrefs.DeleteAll();
            
            UpdateDate.Invoke(0);
        }
    }
}

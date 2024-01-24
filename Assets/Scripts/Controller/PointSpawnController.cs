using UnityEngine;

namespace Controller
{
    public class PointSpawnController : MonoBehaviour
    {
        private bool _isSomeoneWort = false;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                _isSomeoneWort = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag(GlobalConstants.PLAYER_TAG))
            {
                _isSomeoneWort = false;
            }
        }
        public bool ChecksObjectsZoneSpawn()
        {
            return _isSomeoneWort;
        }
    }
}

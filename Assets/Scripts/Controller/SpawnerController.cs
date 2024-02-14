using UnityEngine;

namespace Controller
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField]
        private Transform[] _pointsSpawn;

        [SerializeField]
        private GameObject _player;

        private void Awake()
        {
            _player.transform.position = _pointsSpawn[RandomNumberGenerator.RandomNumber(0,_pointsSpawn.Length,false)].position;
            Destroy(this);
        }
    }
}

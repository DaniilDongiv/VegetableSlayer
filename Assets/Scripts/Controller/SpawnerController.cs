using System;
using UnityEngine;
using Random = UnityEngine.Random;

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
            ChangePosition();
            Destroy(this);
        }

        private void ChangePosition()
        {
            _player.transform.position = _pointsSpawn[RandomNumberPointSpawnEnemy()].position;
        }
        
        private int RandomNumberPointSpawnEnemy()
        {
            var numberPointRandom = Random.Range(0, _pointsSpawn.Length);
            return numberPointRandom;
        }
    }
}

using UnityEngine;
using UnityEngine.Events;

namespace Controller
{
    public class GeneratingBonusesController : MonoCache
    {
        public UnityEvent<Transform> BonusesSpawner;
        
        [SerializeField]
        private GameObject _prefabBonuses;
        [SerializeField]
        private Transform[] _pointsSpawnBonuses;

        private int _time = 20;
        private float _currentTime;

        private PointSpawnController _pointSpawnController;
        
        private void Start()
        {
            _currentTime = _time;
        }

        public override void OnTick()
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                SpawnBonuses();
                _currentTime = _time;
            }
        }

        private void SpawnBonuses()
        {
            var enemy =Instantiate(_prefabBonuses);
            enemy.transform.position = _pointsSpawnBonuses[NumberPointZoneSpawn()].position;
            BonusesSpawner.Invoke(enemy.transform);
        }

        private int NumberPointZoneSpawn()
        {
            var number = RandomNumberPointSpawnEnemy();
            var isMaySpawn = _pointsSpawnBonuses[number].GetComponent<PointSpawnController>().ChecksObjectsZoneSpawn();
            while (isMaySpawn)
            {
                number = RandomNumberPointSpawnEnemy();
                isMaySpawn = _pointsSpawnBonuses[number].GetComponent<PointSpawnController>().ChecksObjectsZoneSpawn();
            }

            return number;
        }
        
        private int RandomNumberPointSpawnEnemy()
        {
            var numberPointRandom = Random.Range(0, _pointsSpawnBonuses.Length);
            return numberPointRandom;
        }
    }
}

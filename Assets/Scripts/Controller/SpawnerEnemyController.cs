using Enemy;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Controller
{
    public class SpawnerEnemyController : MonoCache
    {
        public UnityEvent<Transform> EnemySpawner;
        
        [SerializeField]
        private EnemyController[] _prefabsEnemy;
        [SerializeField]
        private Transform[] _pointsSpawnEnemy;

        private int _time = 9;
        private float _currentTime;

        private PointSpawnController _pointSpawnController;
        
        private void Start()
        {
            _currentTime = 2f;
        }

        public override void OnTick()
        {
            _currentTime -= Time.deltaTime;
            if (_currentTime <= 0)
            {
                SpawnEnemy();
                if (_time>=4)
                {
                    _time -= 1;
                }
                _currentTime = _time;
            }
        }

        private void SpawnEnemy()
        {
            var enemy =Instantiate(_prefabsEnemy[RandomNumberPrefabEnemy()]);
            enemy.transform.position = _pointsSpawnEnemy[NumberPointZoneSpawn()].position;
            EnemySpawner.Invoke(enemy.transform);
        }
        
        private int RandomNumberPrefabEnemy()
        {
            return Random.Range(0, _prefabsEnemy.Length);
        }

        private int NumberPointZoneSpawn()
        {
            var number = RandomNumberPointSpawnEnemy();
            var isMaySpawn = _pointsSpawnEnemy[number].GetComponent<PointSpawnController>().ChecksObjectsZoneSpawn();
            while (isMaySpawn)
            {
                number = RandomNumberPointSpawnEnemy();
                isMaySpawn = _pointsSpawnEnemy[number].GetComponent<PointSpawnController>().ChecksObjectsZoneSpawn();
            }

            return number;
        }
        
        private int RandomNumberPointSpawnEnemy()
        {
            var numberPointRandom = Random.Range(0, _pointsSpawnEnemy.Length);
            return numberPointRandom;
        }
        
        
    }
}

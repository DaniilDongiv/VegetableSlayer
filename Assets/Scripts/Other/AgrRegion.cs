using System;
using Enemy;
using UnityEngine;

public class AgrRegion : MonoBehaviour
{
    public event Action<EnemyController> OnEnemyGetIntoAgrRegion;
    public event Action<EnemyController> OnEnemyGetOutAgrRegion;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag(GlobalConstants.ENEMY_TAG))
        {
            OnEnemyGetIntoAgrRegion?.Invoke(collider.gameObject.GetComponent<EnemyController>());
        }
    }
    
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag(GlobalConstants.ENEMY_TAG))
        {
            OnEnemyGetOutAgrRegion?.Invoke(collider.gameObject.GetComponent<EnemyController>());
        }
    }
}
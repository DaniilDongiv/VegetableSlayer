using System.Collections.Generic;
using UnityEngine;

public abstract class MonoCache : MonoBehaviour
{
    public static List<MonoCache> AllUpdate = new List<MonoCache>(10001);

    private void OnEnable() => AllUpdate.Add(this);

    private void OnDisable() => AllUpdate.Remove(this);

    private void OnDestroy() => AllUpdate.Remove(this);

    public void Tick() => OnTick();
    
    public virtual void OnTick(){}
}

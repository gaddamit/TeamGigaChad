using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCollectables {  get; private set; }
    public UnityEvent<PlayerInventory> OnCollectableCount; 

    public void CollectableCount()
    {
        NumberOfCollectables++;
        OnCollectableCount.Invoke(this);
    }
}

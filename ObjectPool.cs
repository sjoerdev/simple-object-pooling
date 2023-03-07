using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // This is a prefab of the type of object that may exist in the pool
    public GameObject pooledObject;

    // This is the size of the pool
    public int poolSize = 5;

    // This is the stack in which the objects are stored in memory
    private Stack<PoolItem> objectPool;

    // This function is called on game start
    private void Start()
    {
        objectPool = new Stack<PoolItem>(poolSize);
        Expand(poolSize);
    }

    // Fill the pool with gameObjects
    private void Expand(int expansionSize)
    {
        for (int i = 0; i < expansionSize; i++)
        {
            GameObject newObject = Instantiate(pooledObject);
            PoolItem item = newObject.GetComponent<PoolItem>();
            item.objectPool = this;
            ReturnPooledObject(item);
        }
    }

    // Takes the item from the pool and activates it
    public GameObject GetPooledObject(Vector3 position, Quaternion rotation, Transform parent = null)
    {
        if (objectPool.Count == 0) return null;

        PoolItem item = objectPool.Pop();
        item.Init(position, rotation, parent != null ? parent : transform);
        item.gameObject.SetActive(true);
        return item.gameObject;
    }

    // Returns the item to the pool and deactivates it
    public void ReturnPooledObject(PoolItem item)
    {
        if (!item.gameObject.activeSelf) return;
        item.transform.parent = transform;
        item.gameObject.SetActive(false);
        objectPool.Push(item);
    }
}

using UnityEngine;

public class PoolItem : MonoBehaviour
{
    // The object pool we belong to
    public ObjectPool objectPool;

    // This is called just before we activate this item
    protected virtual void Activate(){}

    // This is called just before we deactivate this item
    protected virtual void Deactivate(){}

    // Initialize the transform of this pool item
    public void Init(Vector3 position, Quaternion rotation, Transform parent)
    {
        transform.position = position;
        transform.rotation = rotation;
        transform.parent = parent;
        Activate();
    }

    // Teturn the item to the pool
    public void ReturnToPool()
    {
        Deactivate();
        objectPool.ReturnPooledObject(this);
    }
}

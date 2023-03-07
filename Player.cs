using UnityEngine;

public class Player : MonoBehaviour
{
    // This is the object pool in which the bullets are stored
    public ObjectPool bulletPool;


    // This is called every frame (Gets a bullet from the object pool when space is pressed)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _ = bulletPool.GetPooledObject(transform.position, transform.rotation, null);
        }
    }
}

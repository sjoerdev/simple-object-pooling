using UnityEngine;

public class Bullet : PoolItem
{
    // This is the speed of the bullet
    [SerializeField] float speed = 10.0f;

    // This is the amount of time after which the bullet gets returned to the pool
    [SerializeField] float lifeTime = 3.0f;

    // This timer keeps track of how long the bullet has been active
    private float deathTimer;

    // This is called uppon the activation of the bullet
    protected override void Activate()
    {
        deathTimer = 0;
    }

    // Called every frame (move bullet and keep track of deathtimer)
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        deathTimer += Time.deltaTime;
        if (deathTimer >= lifeTime) ReturnToPool();
    }
}

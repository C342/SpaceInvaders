using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour
{
    public Vector3 direction = Vector3.up;
    public float speed = 20f;
    public float maxDistancePerFrame = 1f;
    public PlayerShooting shooter;

    void Update()
    {
        transform.position += speed * Time.deltaTime * direction;

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.y > 1 || viewPos.y < 0 || viewPos.x < 0 || viewPos.x > 1)
        {
            if (shooter != null)
                shooter.NotifyLaserDestroyed(gameObject);

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Invader"))
        {
            if (shooter != null)
                shooter.NotifyLaserDestroyed(gameObject);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void CheckCollision(Collider2D other)
    {
        Bunker bunker = other.gameObject.GetComponent<Bunker>();
        if (bunker == null || bunker.CheckCollision(GetComponent<BoxCollider2D>(), transform.position))
        {
            if (shooter != null)
                shooter.NotifyLaserDestroyed(gameObject);

            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        if (shooter != null)
            shooter.NotifyLaserDestroyed(gameObject);
    }
}
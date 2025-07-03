using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Projectile : MonoBehaviour
{
    public Vector2 direction = Vector2.up;
    public float speed = 20f;
    public PlayerShooting shooter;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.isKinematic = true;
    }

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;

        transform.position += (Vector3)(direction * moveDistance);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            if (shooter != null)
                shooter.NotifyLaserDestroyed(gameObject);

            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Invader"))
        {
            if (shooter != null)
                shooter.NotifyLaserDestroyed(gameObject);

            Destroy(collision.gameObject);  // Destroy enemy
            Destroy(gameObject);            // Destroy laser
        }
        else
        {
            Bunker bunker = collision.collider.GetComponent<Bunker>();
            if (bunker == null || bunker.CheckCollision(GetComponent<BoxCollider2D>(), transform.position))
            {
                if (shooter != null)
                    shooter.NotifyLaserDestroyed(gameObject);

                Destroy(gameObject);
            }
        }
    }

    void OnDestroy()
    {
        if (shooter != null)
            shooter.NotifyLaserDestroyed(gameObject);
    }
}
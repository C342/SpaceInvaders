using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 5f;
    [SerializeField] private float raycastDistance = 0.2f;
    [SerializeField] private LayerMask invaderLayer;

    public delegate void LaserDestroyedHandler(Projectile projectile);
    public event LaserDestroyedHandler OnLaserDestroyed;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        Vector2 direction = Vector2.up;
        float moveDistance = speed * Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance, invaderLayer);
        if (hit.collider != null && hit.collider.CompareTag("Invader"))
        {
            Destroy(hit.collider.gameObject); // kill invader
            Destroy(gameObject); // destroy laser
            OnLaserDestroyed?.Invoke(this);
            return;
        }

        transform.Translate(direction * moveDistance);
    }

    private void OnBecameInvisible()
    {
        OnLaserDestroyed?.Invoke(this);
        Destroy(gameObject);
    }
}
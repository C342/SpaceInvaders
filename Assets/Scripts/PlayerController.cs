using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;

    private const float maxLeft = -8.12f;
    private const float maxRight = 8.12f;

    private float speed = 3;
    private bool isShooting = false;

    void Update()
    {
#if (InputGetKey(Keycode.A) && transform.position.x > maxLeft;
    transform.Translate(Vector2.left * Time.deltaTime * speed);

    if(Input.GetKey(Keycode.D) && transform.position.x < maxRight;
    transform.Translate(Vector2.right * Time.deltaTime * speed);

    if(Input.(Keycode.Space) && !isShooting
        StartCoRoutine(shoot);
#endif
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return null;
        isShooting=false;
    }
}
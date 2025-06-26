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
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A) && transform.position.x > maxLeft)
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if(Input.GetKey(KeyCode.D) && transform.position.x < maxRight)
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        if (Input.(KeyCode.Space) && !isShooting)
            StartCoroutine(Shoot);
#endif
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        yield return null;
        isShooting = false;
    }
}
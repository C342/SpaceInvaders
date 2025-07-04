using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform firePoint;

    private bool canFire = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            FireArc();
        }
    }

    void FireArc()
    {
        canFire = false;
        float[] angles = { -15f, 0f, 15f };

        foreach (float angle in angles)
        {
            GameObject laserGO = Instantiate(laserPrefab, firePoint.position, Quaternion.Euler(0, 0, angle));
        }

        Invoke(nameof(EnableFire), 0.5f);
    }

    void EnableFire()
    {
        canFire = true;
    }
}
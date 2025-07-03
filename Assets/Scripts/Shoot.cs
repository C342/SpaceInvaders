using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Transform firePoint;
    public float spreadAngle = 20f;

    private GameObject currentLaser;
    private List<GameObject> activeLasers = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && activeLasers.Count == 0)
        {
            FireShotgun();
        }
    }
    void FireShotgun()
    {
        for (int i = 0; i < 3; i++)
        {
            float angle = -spreadAngle + i * (spreadAngle * 2f / 2f);
            Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;

            GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            Projectile p = proj.GetComponent<Projectile>();
            if (p != null)
            {
                p.direction = dir;
                p.shooter = this;
                activeLasers.Add(proj);
            }
        }
    }
    public void ClearLaser()
    {
        currentLaser = null;
    }

    public void NotifyLaserDestroyed(GameObject laser)
    {
        activeLasers.Remove(laser);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;

    private Vector3 hMoveDistance = new Vector3(0, 0, 0);
    private Vector3 vMoveDistance = new Vector3(0, 0, 0);

    private const float maxLeft = -8.12f;
    private const float maxRight = 8.12f;
    private const float maxMoveSpeed = 0.02f;

    private float moveTimer = 0.01f;
    private const float moveTime = 0.005f;

    private bool movingRight;

    public static List<GameObject> allAliens = new List<GameObject>();
    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            allAliens.Add(go);
        }
    }

    void Update()
    {
        if (moveTimer <= 0)
        {
            MoveEnemies();

            moveTimer -= Time.deltaTime;
        }
    }

    private void MoveEnemies()
    {
        if (allAliens.Count > 0)
        {
            int hitMax = 0;

            for (int i = 0; i < allAliens.Count; i++)
            {
                if (movingRight)
                {
                    allAliens[i].transform.position += hMoveDistance;
                }
                else
                {
                    allAliens[i].transform.position += vMoveDistance;

                    if (allAliens[i].transform.position.x > maxRight || allAliens[i].transform.position.x < maxLeft)
                    {
                        hitMax++;
                    }
                }

                if (hitMax > 0)
                {
                    for (int i = 0; i < allAliens.Count; i++)
                    {
                        allAliens[i].transform.position -= vMoveDistance;

                        movingRight = !movingRight;
                    }
                }
            }
        }
    }

    private float GetMoveSpeed()
    {
        float f = allAliens.Count * moveTime;

        if (f < maxMoveSpeed)
        {
            return maxMoveSpeed;
        }
        else
        {
            return f;
        }
    }
}
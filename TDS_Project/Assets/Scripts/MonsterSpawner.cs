using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float spawnTime;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime > 2f)
        {
            spawnTime = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject monster = GameManager.instance.pool.Get(0);
        monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}



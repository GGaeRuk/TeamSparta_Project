using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float spawnTime;

    private int[] layer = new int[3] { 7, 8, 9 };

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();

        Physics.IgnoreLayerCollision(layer[0], layer[1], false);
        Physics.IgnoreLayerCollision(layer[0], layer[2], false);
        Physics.IgnoreLayerCollision(layer[1], layer[2], false);
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
        int pick = Random.Range(1, spawnPoint.Length);

        monster.layer = layer[pick - 1];
        monster.transform.position = spawnPoint[pick].position;
    }
}



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

        // Edit -> ProjcetSettings -> Physics2D 설정으로 충돌처리 해결
    }
}



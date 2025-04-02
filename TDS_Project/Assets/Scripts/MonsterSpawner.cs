using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float interval = 2.0f;

    private float[] spawnPositionsY = new float[] {
        1f,
        0.5f,
        0.0f
    };

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            int monsterCount = Random.Range(1, 3);
            float spawnY = spawnPositionsY[Random.Range(0, spawnPositionsY.Length)];

            for(int i = 0; i < monsterCount; i++)
            {
                Vector3 spawnPosition = new Vector3(
                                        transform.position.x, 
                                        transform.position.y + spawnY,
                                        transform.position.z);

                Instantiate(monsterPrefab, spawnPosition, transform.rotation);
            }
        }
    }
}



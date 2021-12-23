using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class Spawner : MonoBehaviour
{
    
    public GameObject enemyPrefab;
    public GameObject directionFolder;
    public int childCount;
    public Text waveCount,enemyCount;
    public int waves;
    public int enemiesToSpawn;
    public int enemySpeed;
    private void Start()
    {
        enemySpeed = 3;
        waves = 0;
        enemiesToSpawn = 20;
    }

    private void Update()
    {
        if (transform.childCount == 0)
        {
            for (int i = 0; i < directionFolder.transform.childCount; i++)
            {
                Destroy(directionFolder.transform.GetChild(i).gameObject);
                
            }
            InvokeRepeating("SpawnEnemies", 0, 1f);
            enemiesToSpawn += 8;
            waves++;
            waveCount.text = $"wave: {waves}";
            enemySpeed += 2;

        }
        enemyCount.text = $"Enemy count: {transform.childCount}";

    }
    private void SpawnEnemies()
    {


        
        int i = Random.Range(55, 45);
        Instantiate(enemyPrefab, new Vector3(Random.Range(i,i), Random.Range(i, i), 0),Quaternion.identity,transform);
        Instantiate(enemyPrefab, new Vector3(Random.Range(i, -i), Random.Range(i, -i), 0), Quaternion.identity, transform);
        Instantiate(enemyPrefab, new Vector3(Random.Range(-i, i), Random.Range(-i, i), 0), Quaternion.identity, transform);
        Instantiate(enemyPrefab, new Vector3(Random.Range(-i, -i), Random.Range(-i, -i), 0), Quaternion.identity, transform);
        childCount = transform.childCount;
        if (childCount > enemiesToSpawn)
        {
            CancelInvoke("SpawnEnemies");
            
            for ( int k=0;k<transform.childCount;k++)
            {
                transform.GetChild(k).GetComponent<AILerp>().speed = enemySpeed;
            }
        }

        
    }
}

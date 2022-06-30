using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class waveManager : MonoBehaviour
{
    public static waveManager instance;

    private float spawnRange = 10;
    private float spawnYMin = -15;
    private float spawnYMax = 15;

    public int enemyCount;
    public int yellowCount = 0;
    public int redCount = 0;
    public int waveCount = 1;

    public GameObject[] enemies;
    public GameObject[] spawnPoints;
    public TextMeshPro waveText;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnEnemyWave(waveCount);
        waveText.text = "Wave: 1";
    }

    void FixedUpdate()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0 && playerMove.instance.health > 0)
        {
            Debug.Log("Update method is calling an enemy");
            waveCount++;
            SpawnEnemyWave(waveCount);
            waveText.text = "Wave: " + waveCount.ToString();
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        yellowCount = 0;
        redCount = 0;

        // starts spawning the enemies for the wave
        for (int i = 0; i < enemiesToSpawn; i++)
          {
            int randEnemy = Random.Range(0, enemies.Length);
            Debug.Log("Spawning enemy " + enemiesToSpawn);
            if (randEnemy >= 0 && randEnemy <= 4)
            {
                yellowCount++;
                Instantiate(enemies[randEnemy], GenerateSpawnPosition(), enemies[randEnemy].transform.rotation);
            }
            else if (randEnemy >= 5 && randEnemy <= 7)
            {
                redCount++;
                Instantiate(enemies[randEnemy], GenerateSpawnPosition(), enemies[randEnemy].transform.rotation);
            }
            else
            Instantiate(enemies[randEnemy], GenerateSpawnPosition(), enemies[randEnemy].transform.rotation);
          }
    }

    Vector2 GenerateSpawnPosition()
    {
        float xPos = Random.Range(-spawnRange, spawnRange);
        float yPos = Random.Range(spawnYMin, spawnYMax);
        return new Vector2(xPos, yPos);
    }
}
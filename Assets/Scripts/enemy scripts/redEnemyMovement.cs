using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redEnemyMovement : MonoBehaviour
{
    public static redEnemyMovement instance;

    public bool metSpawnpoint = false;

    public float speed = 5.0f;
    public int randSpawn;
    public Vector3 lookDirection;

    float posX = 0f;
    float posY = 0f;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GenSpawnPoint();
    }

    void Update()
    {
        posX = gameObject.transform.position.x;
        posY = gameObject.transform.position.y;

        transform.Translate(lookDirection * Time.deltaTime * speed);

        // when the spawnpoint detects collision with the red enemies in redTestScript.cs, it sends a message back here
        // this functionality allows repeat journeys from point to point
        if (metSpawnpoint == true)
        {
            GenSpawnPoint();
        }

        if (posX < -37f || posX > 31 || posY < -24 || posY > 25)
        {
            scoreManager.instance.addPoints(0);
            Destroy(gameObject);
            waveManager.instance.redCount--;
        }
    }

    void GenSpawnPoint()
    {
        // sets lookDirection to the location of a random spawnPoint and sets the onJouney bool to true, sending the red enemy on its journey
        randSpawn = Random.Range(0, waveManager.instance.spawnPoints.Length);
        lookDirection = (waveManager.instance.spawnPoints[randSpawn].transform.position - transform.position).normalized;

        metSpawnpoint = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redTestScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // sends a message to redEnemyMovement.cs when the red enemy makes contact with the spawnpoint
        // putting the trigger detection in this script rather than the movement script made it more reliable overall
        if (collision.tag == "Enemy")
        {
            redEnemyMovement.instance.metSpawnpoint = true;
        }
    }
}
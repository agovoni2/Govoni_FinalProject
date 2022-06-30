using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    // For clarification, this script applies to the yellow enemy only

    public float speed = 5.0f;
    public float rotationSpeed = 200f;
    public bool canDoDamage = false;

    public GameObject yellowEnemy, player;
    public Sprite normalSprite, passiveSprite;

    public float waitTime = .5f;

    void Start()
    {
        // starts a timer when the enemy is spawned in that prevents it from doing damage to the player for a bit
        // this is to ensure the player is able to reposition if needed. the enemy is also invincible during this time
        StartCoroutine("DamageClock");
    }

    IEnumerator DamageClock()
    {
        yield return new WaitForSeconds(waitTime);
        canDoDamage = true;
    }

    void Update()
    {
        // spins the enemy for aesthetic purposes
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        // changes enemy sprite to indicate if it can do damage or not
        if (canDoDamage == false)
            yellowEnemy.GetComponent<SpriteRenderer>().sprite = passiveSprite;
        if (canDoDamage == true)
            yellowEnemy.GetComponent<SpriteRenderer>().sprite = normalSprite;

        // destroys the enemy if the player is no longer present
        if (playerMove.instance.health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // take damage from player
        if (collision.tag == "Bullet" && canDoDamage == true)
        {
            scoreManager.instance.addPoints(5);
            Destroy(transform.parent.gameObject);
            waveManager.instance.yellowCount--;
        }

        // deal damage to player
        if (collision.tag == "Player" && canDoDamage == true)
        {
            soundManager.PlaySound("player_damage");
            Debug.Log("Contact with player");
            playerMove.instance.health--;
        }
    }
}
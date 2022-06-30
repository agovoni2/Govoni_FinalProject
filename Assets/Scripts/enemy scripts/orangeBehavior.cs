using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orangeBehavior : MonoBehaviour
{
    // orange enemies cannot be destroyed directly by the player
    // orange enemies are destroyed after all other enemies are destroyed

    public float speed = 5.0f;
    public float rotationSpeed = 200f;

    public bool canDoDamage = false;

    public Sprite normalSprite, passiveSprite;

    void Start()
    {
        // starts a timer when the enemy is spawned in that prevents it from doing damage to the player for a bit
        // this is to ensure the player is able to reposition if needed. the enemy is also invincible during this time
        StartCoroutine("DamageClock");
    }

    IEnumerator DamageClock()
    {
        yield return new WaitForSeconds(1.5f);
        canDoDamage = true;
    }

    void Update()
    {
        // spins the enemy for aesthetic purposes
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        if (canDoDamage == false)
            this.GetComponent<SpriteRenderer>().sprite = passiveSprite;
        if (canDoDamage == true)
            this.GetComponent<SpriteRenderer>().sprite = normalSprite;

        // destroys orange enemies after all other enemy types have been destroyed
        if (waveManager.instance.yellowCount <= 0 && waveManager.instance.redCount <= 0)
            Destroy(transform.parent.gameObject);

        // destroys the enemy if the player is no longer present
        if (playerMove.instance.health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // deal damage to player
        if (collision.tag == "Player" && canDoDamage == true)
        {
            soundManager.PlaySound("player_damage");
            Debug.Log("Contact with player");
            playerMove.instance.health--;
        }
    }
}
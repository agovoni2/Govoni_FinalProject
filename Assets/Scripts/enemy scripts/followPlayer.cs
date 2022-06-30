using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public float speed = 5.0f;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("playerCharacter");
    }

    void Update()
    {
        // constantly orients the enemy in the direction of the player and sends them in that direction
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        transform.Translate(lookDirection * Time.deltaTime * speed);
    }
}
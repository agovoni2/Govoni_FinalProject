using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public static AudioClip shootSound, playerDamageSound, pointSound;
    static AudioSource audioSrc;

    void Start()
    {
        shootSound = Resources.Load<AudioClip>("player_shoot");
        playerDamageSound = Resources.Load<AudioClip>("player_damage");
        pointSound = Resources.Load<AudioClip>("point_up");

        audioSrc = gameObject.GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "player_shoot":
                audioSrc.PlayOneShot(shootSound);
                break;
            case "player_damage":
                audioSrc.PlayOneShot(playerDamageSound);
                break;
            case "point_up":
                audioSrc.PlayOneShot(pointSound);
                break;
        }
    }
}

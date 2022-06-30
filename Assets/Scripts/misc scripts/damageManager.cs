using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class damageManager : MonoBehaviour
{
    public GameObject battery;
    public Sprite b6, b5, b4, b3, b2, b1;

    public GameObject[] objectsToDisable;
    public GameObject[] objectsToEnable;
    int int_objectsToDisable;
    int int_objectsToEnable;

    public TextMeshPro scoreText;

    private void Start()
    {
        int_objectsToDisable = objectsToDisable.Length;
        int_objectsToEnable = objectsToEnable.Length;
    }

    void Update()
    {
        DamageCheck();
    }

    public void DamageCheck()
    {
        if (playerMove.instance.health == 6)
        {
            battery.GetComponent<SpriteRenderer>().sprite = b6;
        }
        else if (playerMove.instance.health == 5)
        {
            battery.GetComponent<SpriteRenderer>().sprite = b5;
        }
        else if (playerMove.instance.health == 4)
        {
            battery.GetComponent<SpriteRenderer>().sprite = b4;
        }
        else if (playerMove.instance.health == 3)
        {
            battery.GetComponent<SpriteRenderer>().sprite = b3;
        }
        else if (playerMove.instance.health == 2)
        {
            battery.GetComponent<SpriteRenderer>().sprite = b2;
        }
        else if (playerMove.instance.health == 1)
        {
            battery.GetComponent<SpriteRenderer>().sprite = b1;
        }
        else if (playerMove.instance.health <= 0)
        {
            for (int i = 0; i < int_objectsToDisable; i++)
            {
                objectsToDisable[i].SetActive(false);  
            }

            scoreText.text = "Your score: " + scoreManager.instance.score + "\n Highest wave: " + waveManager.instance.waveCount.ToString();

            for (int i = 0; i < int_objectsToEnable; i++)
            {
                objectsToEnable[i].SetActive(true);
            }

            battery.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeListener : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape pressed");
            Application.Quit();
        }
    }
}
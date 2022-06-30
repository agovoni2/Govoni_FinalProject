using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButtonScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("<<Loading Game>>");
        SceneManager.LoadScene(1);
    }
}
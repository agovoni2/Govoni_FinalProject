using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitButtonScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("<<Quitting Game>>");
        Application.Quit();
    }
}

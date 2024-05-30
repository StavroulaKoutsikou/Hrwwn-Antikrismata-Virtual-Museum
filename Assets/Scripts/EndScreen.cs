using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] GameObject endGameCanvas;

    public void ShowEndGameCanvas()
    {
        endGameCanvas.SetActive(true);
    }
}

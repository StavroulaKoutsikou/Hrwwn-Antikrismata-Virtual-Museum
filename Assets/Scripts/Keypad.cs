using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keypad : MonoBehaviour
{
    public TMP_InputField CharHolder;

    public GameObject clearButton;
    public GameObject enterButton;

    public EnterAnswerMenu enterAnswerMenu; // Reference to the EnterAnswerMenu script


    public void clearButtonFunction()
    {
        CharHolder.text = null;
    }

    public void enterButtonFunction()
    {
        if (CharHolder.text == "ΝΙΚΟΣΓΑΛΑΤΗΣ")
        {
            Debug.Log("Σωστα");
            enterAnswerMenu.ShowCorrectAnswerCanvas(); // Call method to show the correct answer canvas
        }
        else
        {
            Debug.Log("Λαθος");
        }
    }
}

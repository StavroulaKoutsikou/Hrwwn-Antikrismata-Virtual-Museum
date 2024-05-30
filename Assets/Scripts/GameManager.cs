using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    QuizManager quiz;
    EndScreen endScreen;
    void Awake()
    {
        quiz = FindObjectOfType<QuizManager>();
        endScreen = FindObjectOfType<EndScreen>();

        if (endScreen == null)
        {
            Debug.LogError("EndScreen not found in the scene!");
        }
    }

    void Start()
    {

        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);


    }

    void Update()
    {
        if(quiz.isComplete)
        {
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
            endScreen.ShowEndGameCanvas();
        }
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene("QuizGame");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timerValue;
    public bool isAnsweringQuestion = false;
    public float fillFraction;
    public bool loadNextQuestion = true;
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;


    void Update()
    {
        updateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void updateTimer()
    {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if(timerValue >0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;
            }
        }
       // Debug.Log(isAnsweringQuestion + ": " + timerValue + "= " + fillFraction);

    }
}

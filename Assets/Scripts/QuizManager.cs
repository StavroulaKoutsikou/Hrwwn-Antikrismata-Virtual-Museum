using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header("Buttons")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;


    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    public bool isComplete;


    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        
        GetNextQuestion();       
        progressBar.maxValue = questions.Count;
        progressBar.value = 0; 
    }


    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            if(progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    void DisplayAnswer(int index)
    {
        Image buttonImage;
        if(index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Σωστά!";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            
        }
        else
        {
            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            questionText.text = "Κρίμα! η σωστή απάντηση ήταν: \n" + correctAnswer;
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;

        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        


    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        GetRandomQuestion();
        DisplayQuestion();
        progressBar.value++;
       
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0,questions.Count);
        currentQuestion = questions[index];

        if(questions.Contains(currentQuestion)){
            questions.Remove(currentQuestion);
        }
        
    }

    private void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }


    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for(int i = 0; i<answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
        

    }

}

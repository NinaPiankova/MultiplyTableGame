using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GlobalLevelSettings LevelCreator;

    public Slider timerSlider;
    public Text timerText;

    private float gameTime;

    private bool stopTimer;

    int timerCounter;

    // Start is called before the first frame update
    void Start()
    {

        gameTime = LevelCreator.timePeriod;

        stopTimer = false;
        timerSlider.maxValue = LevelCreator.timePeriod;
        timerSlider.value = LevelCreator.timePeriod;
        timerCounter = LevelCreator.exampleCounter;//колличество примеров

    }


    // Update is called once per frame
    void Update()
    {

        if (stopTimer == false)
        {
            float time = gameTime - Time.time;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);
            string textTime = minutes.ToString("00") + ":" + seconds.ToString("00"); ;//minutes.ToString("{0,1:}",minutes)

            if(time <= 0)
            {
                stopTimer = true;
            }
            else
            {
                timerText.text = textTime;
                timerSlider.value = time;
            }
        }

        else
        {
            gameTime = LevelCreator.timePeriod;
            timerSlider.maxValue = LevelCreator.timePeriod;
            timerSlider.value = LevelCreator.timePeriod;
            stopTimer = false;           
        }


     /*       float time = gameTime - Time.time;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string textTime = minutes.ToString("00") + ":" + seconds.ToString("00"); ;//minutes.ToString("{0,1:}",minutes)

             timerText.text = textTime;
             timerSlider.value = time;


        if (time <= 0)
            {
                stopTimer = true;

                Debug.Log("ВЫВЕСТИ ЗНАЧЕНИЕ"+LevelCreator.timePeriod);
                UpdatesValues();
            }

           /* if (stopTimer == false)
            {
                timerText.text = textTime;
                timerSlider.value = time;
            }
        */




    }

    private void UpdatesValues()
    {
        gameTime = LevelCreator.timePeriod;        
        timerSlider.maxValue = LevelCreator.timePeriod;
        timerSlider.value = LevelCreator.timePeriod;
        stopTimer = false;

    }
}

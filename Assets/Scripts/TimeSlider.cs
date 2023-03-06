using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    /* public GlobalLevelSettings LevelCreator;

     //public ExamleCreator examle;
     float maxTime;
     float reducedtime;
     public Slider slider;
    */

    public GlobalLevelSettings LevelCreator;
    public Slider slider;
    public Text timerText;

    private float gameTime;
    private bool stopTimer;
    private int timerCounter;
    private float time;
    private bool clickReaction;
    private float waiteTimeForTimer;

    // Start is called before the first frame update
    void Start()
    {
        timerCounter = LevelCreator.exampleCounter;
        slider.maxValue = LevelCreator.timePeriod;
        clickReaction = LevelCreator.buttonReaction;
        waiteTimeForTimer = LevelCreator.waitTimePeriod;
        UpdateValues();
    }

    private void UpdateValues()
    {       
        gameTime = LevelCreator.timePeriod;
        slider.value = gameTime;
        time = gameTime;
        stopTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(clickReaction==false)
        {
            if (!stopTimer && timerCounter > 0)
            {
               
                time -= Time.deltaTime;//1f;
                int minutes = Mathf.FloorToInt(time / 60);
                int seconds = Mathf.FloorToInt(time - minutes * 60f);
                string textTime = minutes.ToString("00") + ":" + seconds.ToString("00"); ;//minutes.ToString("{0,1:}",minutes)
                clickReaction = LevelCreator.buttonReaction;                                                                         //slider.value = time;

                if (time <= 0)
                {
                    stopTimer = true;
                    LevelCreator.timeIsOver = true;
                    timerCounter--;
                }

                else
                {
                    
                    slider.value = time;
                    timerText.text = textTime;
                }
            }
            else if (stopTimer && timerCounter > 0)
            {
                
                UpdateValues();
            }

            else if (timerCounter == 0)
            {
                slider.value = 0;
                timerText.text = "¬ÂÏˇ ËÒÚÂÍÎÓ";
            }
        }

        else if(clickReaction == true)
        {
            
            slider.value = 0;

            if (waiteTimeForTimer > 0)
            {
                waiteTimeForTimer -= Time.deltaTime;//3f;
                //Debug.Log("¬–≈Ãﬂ Œ∆»ƒ¿Õ»ﬂ"+ waiteTimeForTimer);
            }
            waiteTimeForTimer = LevelCreator.waitTimePeriod;
            time = LevelCreator.timePeriod;
            clickReaction = LevelCreator.buttonReaction;
        }





    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    public ExamleCreator examle;
    public GlobalLevelSettings LevelCreator;
    public GameObject TimeSlider;

    
    public Text exampleText;

    List<string> randomExample;        //список примеров
    List<List<int>> ansRandomExample;  //список ответов к ним
    List<int> rightAnswers;            //список правильных ответов

    int indexForExamples;
    int number;//Уменьшает колличество примеров

    private float nextActionTime = 0.0f;



     int ans1;
     int ans2;
     int ans3;
    
    public int rightAns;
   

    public GameObject firstButtonAns;
    public GameObject secondButtonAns;
    public GameObject thirdButtonAns;


    private float gameTime;
    private bool stopTextChanged;
    private float time;
    private float waiteTime;


    // Start is called before the first frame update
    void Start()
    {


        randomExample = examle.textForExamplesUpdates;
        ansRandomExample = examle.answersForExamples;
        rightAnswers = examle.rightAnswersForExamples;
        number = LevelCreator.exampleCounter;
        stopTextChanged=false;
        time = LevelCreator.timePeriod;
        waiteTime = LevelCreator.waitTimePeriod;

    /*
     // Вывести рандомные примеры и ответы к ним
      foreach(string s in randomExample)
    {
        Debug.Log(s);
    }

    foreach (int n in rightAnswers)
    {
        Debug.Log(n);
    }
    */

}

// Update is called once per frame
     void Update()
    {

        if (!LevelCreator.timer && LevelCreator.buttonReaction == false)//Кнопка не нажата и отключен режим таймера
        {
            TimeSlider.SetActive(false);
            TextChangedFunction();
        }

        if (!LevelCreator.timer && LevelCreator.buttonReaction == true)//Кнопка нажата и отключен режим таймера
        {

            TimeSlider.SetActive(false);
            TextChangedFunctionButtonReactionTrue();
        }

        else if (LevelCreator.timer && LevelCreator.buttonReaction == false)//Кнопка не нажата и включен режим таймера
        {
            TextChangedFunction();
        }

        else if (LevelCreator.timer && LevelCreator.buttonReaction == true)//Кнопка нажата и включен режим таймера
        {
            TextChangedFunctionButtonReactionTrue();
        }

    }


    private void TextChangedFunctionButtonReactionTrue()
    {
        if(waiteTime>0&&number>0)
        {
            waiteTime -= Time.deltaTime;//3f;
            exampleText.text = LevelCreator.reactionText;//"Вы нажали на кнопку";// LevelCreator.reactionText;//потом выведу сюда реакцию
            if(firstButtonAns.GetComponentInChildren<Text>().text == rightAns.ToString())
            {
                firstButtonAns.GetComponentInChildren<Text>().text = rightAns.ToString();
                secondButtonAns.GetComponentInChildren<Text>().text = "";
                thirdButtonAns.GetComponentInChildren<Text>().text = "";
            }
            else if(secondButtonAns.GetComponentInChildren<Text>().text == rightAns.ToString())
            {
                firstButtonAns.GetComponentInChildren<Text>().text = "";
                secondButtonAns.GetComponentInChildren<Text>().text = rightAns.ToString();
                thirdButtonAns.GetComponentInChildren<Text>().text = "";
            }
            else if (thirdButtonAns.GetComponentInChildren<Text>().text == rightAns.ToString())
            {
                firstButtonAns.GetComponentInChildren<Text>().text = "";
                secondButtonAns.GetComponentInChildren<Text>().text = "";
                thirdButtonAns.GetComponentInChildren<Text>().text = rightAns.ToString();
            }
            

            //TextChangedWithTimeAndClick();
            //StartCoroutine(StartTimeCoroutineWaitChangedText());


            if (waiteTime <= 0)
            {
                LevelCreator.buttonReaction = false;
                number--;
                waiteTime = LevelCreator.waitTimePeriod;
                time = LevelCreator.timePeriod;
                TextChangedFunction();
            }
        }
        

    }



    private void TextChangedFunction()
    {
        //Функция меняет текст через промежутки времени
        if (!stopTextChanged && number > 0)
        {
           // Debug.Log("Функция меняет текст через промежутки времени: "+time);
            indexForExamples = number - 1; //9
            time -= Time.deltaTime;//1f;
            exampleText.text = randomExample[indexForExamples];
            rightAns = rightAnswers[indexForExamples];
            firstButtonAns.GetComponentInChildren<Text>().text = ansRandomExample[indexForExamples][0].ToString();
            ans1 = ansRandomExample[indexForExamples][0];
            secondButtonAns.GetComponentInChildren<Text>().text = ansRandomExample[indexForExamples][1].ToString();
            ans2 = ansRandomExample[indexForExamples][1];
            thirdButtonAns.GetComponentInChildren<Text>().text = ansRandomExample[indexForExamples][2].ToString();
            ans3 = ansRandomExample[indexForExamples][2];


            //textForExamplesUpdates.Remove(textForExamplesUpdates[indexForExamples]);



            if (time <= 0)
            {
                stopTextChanged = true;
                number--;
            }


        }
        else if (stopTextChanged && number > 0)
        {
            UpdateValuesTime();
        }

        else if (number == 0)
        {
            exampleText.text ="" ;//"Уровень закончился"+"\n"+"Правильных ответов: "+LevelCreator.rightAnsCounter.ToString()+"\n"+"Неверных ответов: "+LevelCreator.wrongAnsCounter.ToString();
            LevelCreator.gameStatusFinished = true;
        }
    }

    private void UpdateValuesTime()
    {
        gameTime = LevelCreator.timePeriod;
        time = gameTime;
        stopTextChanged = false;
    }





}

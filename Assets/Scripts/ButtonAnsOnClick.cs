using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAnsOnClick : MonoBehaviour
{

    public GlobalLevelSettings LevelCreator;

    public GameObject processedButton;
    public TextManager textManager;
    //public GameObject Reaction;

    List<string> reactionRightAnswers = new List<string>() {"Превосходно!","Правильно!","Вау!", "Ты молодец!", "Верный ответ!", "Круто!!!", "Здорово!", "Умница!!!", "Ты настоящий математик!" };
    List<string> reactionWrongAnswers = new List<string>() {"Неверно","Ошибка","Ответ неверный","Неправильно" };

    int rightAnswer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Switch()
    {
        rightAnswer = textManager.rightAns;
        string s = processedButton.GetComponentInChildren<Text>().text;
        int randomIndexForReactons;
        LevelCreator.buttonReaction = true;
        

        if (s== rightAnswer.ToString())
        {
            //Верный ответ
            randomIndexForReactons = UnityEngine.Random.Range(0, reactionRightAnswers.Count);
             LevelCreator.reactionText= reactionRightAnswers[randomIndexForReactons];
             LevelCreator.rightAnsCounter++;
             LevelCreator.error = 2;
            //Debug.Log("ОБРАБОТЧИК "+LevelCreator.error);

        }
        else
        {
            //Неверный ответ - в здоровье персонажа
            randomIndexForReactons = UnityEngine.Random.Range(0, reactionWrongAnswers.Count);
            LevelCreator.reactionText = reactionWrongAnswers[randomIndexForReactons]+"\n"+"Правильный ответ "+ rightAnswer.ToString();
            LevelCreator.wrongAnsCounter++;
            LevelCreator.error = 1;
            //Debug.Log("ОБРАБОТЧИК "+LevelCreator.error);
        }
        
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Array;

public class GlobalLevelSettings : MonoBehaviour
{
    public int levelNumber;          //
    public string studyNumbersStr;   //  Какие числа будет изучать 
    public string secondNumbersStr;  // Второе число в формуле (множитель или делитель и т.д.) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }   
    public int exampleCounter;       //  Какое колличество примеров выводить за одну сессию
    public float timePeriod;         // Время через которое будет выводится новый пример
    public float waitTimePeriod;     // Время ожидания при клике на кнопку
    public bool timer;               //Использовать таймер или нет

    [HideInInspector]
    public bool buttonReaction=false;

    public bool buttleMode;

    [HideInInspector]
    public int error;

    public int numberOfErrorsAllowed;

    [HideInInspector]
    public bool timeIsOver;

    [HideInInspector]
    public float playerHealth;
    [HideInInspector]
    public float enemyHealth;
    [HideInInspector]
    public float damageForPerson;
    [HideInInspector]
    public float damageForEnemy;

    public string positiveReaction;    
    public string negativeReaction;
    [HideInInspector]
    public string reactionText;

    [HideInInspector]
    public int rightAnsCounter;
    [HideInInspector]
    public int wrongAnsCounter;
    [HideInInspector]
    public bool gameStatusFinished=false;//

    public List<OperationEnum> operations;

    private Dictionary<string, ISet<int>> mathExamples;

    public Dictionary<string, ISet<int>> MathExamples 
    {
        get
        {
            return mathExamples;
        } 
    }



    private void Awake()
    {
        int[] studyNumbersArray = ConvertingStringToNumbersArray(studyNumbersStr);
        int[] secondNumbersArray = ConvertingStringToNumbersArray(secondNumbersStr);


        mathExamples = ExampleCreateFunction(studyNumbersArray, secondNumbersArray);



        //Чтобы посмотреть какие примеры и ответы к ним содержит словарь mathExamples

       /* Debug.Log("Вывод примеров:");



        foreach (KeyValuePair<string, ISet<int>> keyValue in mathExamples)
        {
            string strHash = "";

            foreach (int value in keyValue.Value)
            {
                strHash += value.ToString() + "  ";

            }

            Debug.Log(keyValue.Key + " решение: " + strHash);
            Debug.Log("       ");

        }

        */


    }


    private int[] ConvertingStringToNumbersArray(string studyNumbersStr)
    {
            int[] numbers = ConvertAll(studyNumbersStr.Split(','), x => Convert.ToInt32(x));
            return numbers;       
    }


    private Dictionary<string, ISet<int>> ExampleCreateFunction(int[] studyNumbersArray, int[] secondNumbersArray)
    {

        Dictionary<string, ISet<int>> mathExamples = new Dictionary<string, ISet<int>>();
        foreach (OperationEnum op in operations)
        {
           
            switch (op)
            {
                case OperationEnum.ADD:
                    AddFuctionExampleCreate(studyNumbersArray, secondNumbersArray, mathExamples);
                    break;
                case OperationEnum.SUBSTRACT:
                    SubstructFuctionExampleCreate(studyNumbersArray, secondNumbersArray, mathExamples);
                         break;
                case OperationEnum.MULTIPLY:
                    MultiplyFuctionExampleCreate(studyNumbersArray, secondNumbersArray, mathExamples);
                    break;
                case OperationEnum.DIVIDE:
                    DivedeFuctionExampleCreate(studyNumbersArray, secondNumbersArray, mathExamples);
                    break;
            }

        }

        return mathExamples;
        
    }

    private void AddFuctionExampleCreate(int[] studyNumbersArray, int[] secondNumbersArray, Dictionary<string, ISet<int>> addExamplesWithAnswers)
    {

        
        foreach (int number in studyNumbersArray)
         {
             for (int k = 0; k < secondNumbersArray.Length; k++)
             {
                addExamplesWithAnswers.Add(number.ToString() + "+" + secondNumbersArray[k] + "=?"
                     , AnswersMakerAddition(number, secondNumbersArray[k]));
             }

         }
       
    }


    private void SubstructFuctionExampleCreate(int[] studyNumbersArray, int[] secondNumbersArray, Dictionary<string, ISet<int>> addExamplesWithAnswers)
    {


        foreach (int number in studyNumbersArray)
        {
            for (int k = 0; k < secondNumbersArray.Length; k++)
            {
                if(number - secondNumbersArray[k] >= 0)
                {
                    addExamplesWithAnswers.Add(number.ToString() + "-" + secondNumbersArray[k] + "=?"
                         , AnswersMakerSubstruct(number, secondNumbersArray[k]));
                }

            }

        }

    }


    private void MultiplyFuctionExampleCreate(int[] studyNumbersArray, int[] secondNumbersArray, Dictionary<string, ISet<int>> addExamplesWithAnswers)
    {


        foreach (int number in studyNumbersArray)
        {
            for (int k = 0; k < secondNumbersArray.Length; k++)
            {
                addExamplesWithAnswers.Add(number.ToString() + "x" + secondNumbersArray[k] + "=?"
                     , AnswersMakerMultiply(number, secondNumbersArray[k]));
            }

        }

    }


    private void DivedeFuctionExampleCreate(int[] studyNumbersArray, int[] secondNumbersArray, Dictionary<string, ISet<int>> addExamplesWithAnswers)
    {


        foreach (int number in studyNumbersArray)
        {
            for (int k = 0; k < secondNumbersArray.Length; k++)
            {
                addExamplesWithAnswers.Add((number* secondNumbersArray[k]).ToString() + ":" + number.ToString() + "=?"
                     , AnswersMakerDivede(number, secondNumbersArray[k]));
            }

        }

    }




    private ISet<int> AnswersMakerAddition(int number, int v)
    {
        ISet<int> answer = new HashSet<int>();
        answer.Add(number + v);//правильный ответ
        switch (v)
        {
            case 1:
                answer.Add(number +1);
                answer.Add(number -1);
                answer.Add(number + 2);
                answer.Add(number + 3);
                answer.Add(number * v);
                answer.Add(number*10 + v);
                answer.Add(v * 10 + number);
                break;

            case 2:
                answer.Add(number + 1);
                answer.Add(number - 1);
                answer.Add(number + 2);                
                answer.Add(number + 3);
                answer.Add(number * v);
                answer.Add(number * 10 + v);
                answer.Add(v * 10 + number);
                break;
           default:
                answer.Add(number + 1);
                answer.Add(number - 1);
                answer.Add(number + 2);
                answer.Add(v - 2);
                answer.Add(number + 3);
                answer.Add(v - 3);
                answer.Add(number * v);
                answer.Add(number * 10 + v);
                answer.Add(v * 10 + number);
                break;
        }


        return answer;
    }


    private ISet<int> AnswersMakerSubstruct(int number, int v)
    {
        //Вычитание

        ISet<int> answer = new HashSet<int>();
        if(number>=v)
        {
            answer.Add(number - v);
            
            switch (v)
            {
                case 1:
                    answer.Add(number - 1);
                    answer.Add(number + 1);
                    answer.Add(number + 2);
                    answer.Add(number + 3);
                    answer.Add(number * v);
                    answer.Add(number * 10 + v);
                    answer.Add(v * 10 + number);
                    break;

                case 2:
                    answer.Add(number - 1);
                    answer.Add(number + 1);
                    answer.Add(number + 2);
                    answer.Add(number - 2);
                    answer.Add(number + 3);
                    answer.Add(number * v);
                    answer.Add(number * 10 + v);
                    answer.Add(v * 10 + number);
                    break;
                default:
                    answer.Add(number + 1);
                    answer.Add(number - 1);
                    answer.Add(number + 2);
                    answer.Add(number - 2);
                    answer.Add(number + 3);
                    answer.Add(number - 3);
                    answer.Add(number * v);
                    answer.Add(number * 10 + v);
                    answer.Add(v * 10 + number);
                    break;
            }
        }
        

        return answer;
    }


    private ISet<int> AnswersMakerMultiply(int number, int v)
    {
        //Умножение

        ISet<int> answer = new HashSet<int>();
        answer.Add(number * v);

        switch (v)
        {
            case 1:
                answer.Add(number * 2);
                answer.Add(number * 3 );
                answer.Add(number + 1);
                answer.Add(number + 3);               
                answer.Add(number * 10 + 1);
                answer.Add(v * 10 + number);
                break;

            case 2:
                answer.Add(number * 1);
                answer.Add(number * 3);
                answer.Add(number *4 );
                answer.Add(number + 2);
                answer.Add(number + 3);                
                answer.Add(number * 10 + v);
                answer.Add(v * 10 + number);
                break;
            default:
                answer.Add(number * (v - 2));
                answer.Add(number * (v - 1));
                answer.Add(number * (v + 1));
                answer.Add(number * (v + 2));
                answer.Add(number + v);
                //answer.Add(number - 3);
                answer.Add(v);
                answer.Add(number * 10 + v);
                answer.Add(v * 10 + number);
                break;
        }


        return answer;
    }


    private ISet<int> AnswersMakerDivede(int number, int v)
    {
        //Деление
        //number* secondNumbersArray[k]).ToString() + ":" + number.ToString()
        ISet<int> answer = new HashSet<int>();
        answer.Add(v);
        switch (v)
        {
            case 1:
                answer.Add(v + 1);
                answer.Add(v - 1);
                answer.Add(v + 2);
                answer.Add(v + 3);
                answer.Add(number * v);
                answer.Add(number * 10 + v);
                answer.Add(v * 10 + number);
                break;

            case 2:
                answer.Add(v + 1);
                answer.Add(v - 1);
                answer.Add(v + 2);
                answer.Add(v - 2);
                answer.Add(v + 3);
                answer.Add(v * v);
                answer.Add(v * 10 + v);
                answer.Add(v * 10 + number);
                break;
            default:
                answer.Add(v + 1);
                answer.Add(v - 1);
                answer.Add(v + 2);
                answer.Add(v - 2);
                answer.Add(v + 3);
                answer.Add(v - 3);
                answer.Add(v * v);
                answer.Add(number * 10 + v);
                answer.Add(v * 10 + number);
                break;
        }


        return answer;
    }







    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

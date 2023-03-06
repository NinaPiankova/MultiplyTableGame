using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExamleCreator : MonoBehaviour
{

    public GlobalLevelSettings LevelCreator;


    /// <summary>
    /// 
    /// </summary>

    private Dictionary<string, ISet<int>> examplesForMathText;
    public Dictionary<string, ISet<int>> ExamplesForMathText
    {
        get
        {           
            return LevelCreator.MathExamples;
        }

        set
        {

            examplesForMathText = LevelCreator.MathExamples;
        }
    }

    private int numberOfExamples //Колличество примеров, которое должено выводиться
    {
        get
        {
            int countExample= LevelCreator.exampleCounter;
            if (countExample> LevelCreator.MathExamples.Count)
            {
                countExample = LevelCreator.MathExamples.Count;//
            }
            else
            {
                countExample = LevelCreator.exampleCounter;//
            }

            return countExample;
        }

    }

    //public Text exampleText;

    List<int> numbersExampleForMathText;//лист рандомных номеров примеров, в колличестве заданном в настройках
                                        //созданный из списка возможных номеров. Размер списка соответствует настройкам параметра колличество примеров на уровне
    List<string> textForExamples;//текст примеров какие только возможны при заданных настройках    
    public List<string> textForExamplesUpdates; // Сокращенный список рандомных примеров
    public List<List<int>> answersForExamples; //Список наборов ответов на примеры
    public List<int> rightAnswersForExamples;  // Список правильных ответов
 
    
    private int temporaryRightAns;
    List<int> rightAnswers;
    



    // Start is called before the first frame update
    void Start()
    {
      
        List<int> numbersExampleInDictionary = new List<int>();

        //сюда запишем только необходимое колличество примеров, равное numberOfExamples - свойство из LevelCreator
        numbersExampleForMathText = new List<int>();
        for (int i=0;i< LevelCreator.MathExamples.Count;i++)
        {
            numbersExampleInDictionary.Add(i);
        }



        //рандомный список из чисел по которым будем обращаться к словарю
        int randonNumber;
        int n = numbersExampleInDictionary.Count;       
        for (int i=0;i<numberOfExamples;i++) 
        {
            randonNumber = UnityEngine.Random.Range(0, n);
            numbersExampleForMathText.Add(numbersExampleInDictionary[randonNumber]);
            numbersExampleInDictionary.Remove(numbersExampleInDictionary[randonNumber]);
            n--;
        }

       /* foreach(int nu in numbersExampleForMathText)
        {
            Debug.Log("СЧЕТ   " + nu);
        }
       */
        //все примеры/ключи из словаря в идут том порядке, в котором они там находятся, отсюда могу брать ключи по индексу из numberOfExamples
        textForExamples = new List<string>();
        foreach (string s in ExamplesForMathText.Keys)
        {
            textForExamples.Add(s);
        }


        //записали в список textForExamplesUpdates избранные примеры в соответствии со списком рандомных чисел  numbersExampleForMathText
        //записали в список answersForExamples три рандомных ответа - 2 неверных, один верный. Используем функцию CreateRandomAnswers
       

        textForExamplesUpdates = new List<string>();
        answersForExamples = new List<List<int>>();
        rightAnswers = new List<int>();
        for (int i=0;i< numbersExampleForMathText.Count;i++)
        {
            int right;

            textForExamplesUpdates.Add(textForExamples[numbersExampleForMathText[i]]);
            answersForExamples.Add(CreateRandomAnswers(textForExamples[numbersExampleForMathText[i]]));
            rightAnswers.Add(temporaryRightAns);          
        }

        /*
       //Вывести рандомные примеры с ответами 
       List<string> answers1 = new List<string>();
       foreach(List<int> la in answersForExamples)
       {
           string s = "";
           foreach(int number in la)
           {
               s += number.ToString() + " ";
           }
           answers1.Add(s);
       }

       for(int i=0;i< textForExamplesUpdates.Count;i++)
       {

           Debug.Log("РАНДОМНЫЕ ПРИМЕРЫ   "+textForExamplesUpdates[i] + " ответы: " + answers1[i]);
       }

       */




    }


    //Функция возвращает лист из 3х чисел-ответов для текста примера, одно из чисел является верным ответом
    private List<int> CreateRandomAnswers(string v)
    {
        //string v это ключ из словаря

        List<int> TreeAnswersForText = new List<int>();                    
        List<int> AllAnswersForText = new List<int>();

        

        // скопировали значения из словаря, теперь с ними можно работать не опасаясь изменить оригинал
        foreach (int n in ExamplesForMathText[v])
        {
            AllAnswersForText.Add(n);
        }
        temporaryRightAns = AllAnswersForText[0];

        int maxRandomNumber = ExamplesForMathText[v].Count; // сколько всего ответов, в том числе неправильных ответов у примера //6
 
         
        //Создали три неправильных ответа
         for (int i = 0; i < 3; i++)
         {
             int randomNumber = UnityEngine.Random.Range(1, maxRandomNumber);
             TreeAnswersForText.Add(AllAnswersForText[randomNumber]);
             AllAnswersForText.Remove(AllAnswersForText[randomNumber]);
             maxRandomNumber--;
         }

        //добавили рандомно правильный ответ
        int indexRightAnser = UnityEngine.Random.Range(0, 3);    
        TreeAnswersForText[indexRightAnser] = AllAnswersForText[0];
        rightAnswersForExamples.Add(AllAnswersForText[0]);
        return TreeAnswersForText;

    }



    // Update is called once per frame
    void Update()
    {

    }

   


}

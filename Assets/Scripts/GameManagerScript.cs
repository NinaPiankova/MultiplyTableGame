using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GlobalLevelSettings LevelCreator;

    public GameObject canvasBackground;
    public GameObject canvasWinImage;
    public GameObject canvasGameOverImage;
    public GameObject canvasGameStudyImage;
    public GameObject canvasForText;
    public Text textResult;

    public GameObject happyFace;
    public GameObject unhappyFace;
    public GameObject neitralFace;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(LevelCreator.gameStatusFinished==true&& LevelCreator.buttleMode == false)// игра закончена, режим битвы отключен // добавить когда окно win и over
            //Разобраться со статусами
        {

            canvasBackground.SetActive(true);
            canvasGameStudyImage.SetActive(true);
            canvasForText.SetActive(true);
            textResult.text = "Правильных ответов: " + LevelCreator.rightAnsCounter.ToString() + "\n" + "Неверных ответов: " + LevelCreator.wrongAnsCounter.ToString();
            
            if(LevelCreator.rightAnsCounter> LevelCreator.wrongAnsCounter)
            {
                Debug.Log("СЧАСТЛИВОЕ");
                happyFace.SetActive(true);
            }

            else if (LevelCreator.rightAnsCounter == LevelCreator.wrongAnsCounter)
            {
                neitralFace.SetActive(true);
            }

            else if (LevelCreator.rightAnsCounter < LevelCreator.wrongAnsCounter)
            {
                unhappyFace.SetActive(true);
            }


            Time.timeScale = 0;
        }
        else if(LevelCreator.gameStatusFinished == true && LevelCreator.buttleMode == true&& LevelCreator.enemyHealth <= 0)
        {
            canvasBackground.SetActive(true);
            canvasWinImage.SetActive(true);
            canvasForText.SetActive(true);
            textResult.text = "Правильных ответов: " + LevelCreator.rightAnsCounter.ToString() + "\n" + "Неверных ответов: " + LevelCreator.wrongAnsCounter.ToString();
            Time.timeScale = 0;
        }

        else if (LevelCreator.gameStatusFinished == true && LevelCreator.buttleMode == true && LevelCreator.playerHealth <= 0)
        {
            canvasBackground.SetActive(true);
            canvasGameOverImage.SetActive(true);
            canvasForText.SetActive(true);
            textResult.text = "Правильных ответов: " + LevelCreator.rightAnsCounter.ToString() + "\n" + "Неверных ответов: " + LevelCreator.wrongAnsCounter.ToString();
            Time.timeScale = 0;
        }



    }
}

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

    List<string> reactionRightAnswers = new List<string>() {"�����������!","���������!","���!", "�� �������!", "������ �����!", "�����!!!", "�������!", "������!!!", "�� ��������� ���������!" };
    List<string> reactionWrongAnswers = new List<string>() {"�������","������","����� ��������","�����������" };

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
            //������ �����
            randomIndexForReactons = UnityEngine.Random.Range(0, reactionRightAnswers.Count);
             LevelCreator.reactionText= reactionRightAnswers[randomIndexForReactons];
             LevelCreator.rightAnsCounter++;
             LevelCreator.error = 2;
            //Debug.Log("���������� "+LevelCreator.error);

        }
        else
        {
            //�������� ����� - � �������� ���������
            randomIndexForReactons = UnityEngine.Random.Range(0, reactionWrongAnswers.Count);
            LevelCreator.reactionText = reactionWrongAnswers[randomIndexForReactons]+"\n"+"���������� ����� "+ rightAnswer.ToString();
            LevelCreator.wrongAnsCounter++;
            LevelCreator.error = 1;
            //Debug.Log("���������� "+LevelCreator.error);
        }
        
    }


}

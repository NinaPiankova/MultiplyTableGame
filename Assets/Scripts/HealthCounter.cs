using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    public GlobalLevelSettings settings;

    float personHealth;
    float enemyHealth;
    float damagePerson;
    float damageEnemy;
    int errorFlag;

    public GameObject persHealth;
    public GameObject enemHealth;

    public Image psHealth;
    public Image enHealth;


    // Start is called before the first frame update
    void Start()
    {

        personHealth = 1;//
        enemyHealth = 1;//
        damagePerson = 1f / settings.numberOfErrorsAllowed;
        damageEnemy = 1f / (settings.exampleCounter - settings.numberOfErrorsAllowed);

       // Debug.Log("ÇÄÎĞÎÂÜÅ ÏÅĞÑÎÍÀÆÀ "+ personHealth);
       // Debug.Log("ÓĞÎÍ " + damagePerson);
       // Debug.Log("ÇÄÎĞÎÂÜÅ ÂĞÀÃÀ " + enemyHealth);
      //  Debug.Log("ÓĞÎÍ ÂĞÀÃÓ " + damageEnemy);
        errorFlag = settings.error;

        psHealth.fillAmount = personHealth;
        enHealth.fillAmount = enemyHealth;

       if(settings.buttleMode==false)
        {
            persHealth.SetActive(false);
            enemHealth.SetActive(false);
        }
        else
        {
            persHealth.SetActive(true);
            enemHealth.SetActive(true);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(settings.buttleMode == true)
        {
            ChangedHealth();
        }
        
   

    }

    private void ChangedHealth()
    {
        errorFlag = settings.error;
        //Debug.Log(personHealth);

        if (errorFlag == 1)
        {
           // Debug.Log("ÇÀØÅË Â ÇÄÎĞÎÂÜÅ ÏÅĞÑÎÍÀÆÀ");
            psHealth.fillAmount -= damagePerson;
            settings.playerHealth = psHealth.fillAmount*100;
            settings.error = 0;

            if(psHealth.fillAmount <= 0)
            {
                settings.gameStatusFinished = true;
            }

        }
        else if (errorFlag == 2)
        {
           // Debug.Log("ÇÀØÅË Â ÇÄÎĞÎÂÜÅ âğàãà");
            enHealth.fillAmount -= damageEnemy;
            settings.enemyHealth = enHealth.fillAmount * 100;
            settings.error = 0;


            if (enHealth.fillAmount <= 0)
            {
                settings.gameStatusFinished = true;
                Debug.Log(settings.gameStatusFinished);
            }
        }
        else if (settings.timeIsOver==true)
        {
            // Debug.Log("ÇÀØÅË Â ÇÄÎĞÎÂÜÅ ÏÅĞÑÎÍÀÆÀ");
            psHealth.fillAmount -= damagePerson;
            settings.playerHealth = psHealth.fillAmount * 100;
            settings.timeIsOver = false;

            if (psHealth.fillAmount <= 0)
            {
                settings.gameStatusFinished = true;
            }
        }
    }
}

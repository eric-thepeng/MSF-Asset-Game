using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private TMP_Text yearTxt;
    
    private int initialDate = 1900;
    private int currentDate = 1900;
    private float secondsInYear = 1;
    private float timeCount = 0;
    private bool gamePaused = false;
    
    [SerializeField] private int winState = 100;


    private void Awake()
    {
        Ship.shipAmount = 0;
        currentDate = initialDate;
        UpdateText();
    }

    private void Update()
    {
        if (gamePaused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            return;
        }
        if (Money.i.GetAmount() == winState)
        {
            UI.i.Notification("You built your empire in "+ (currentDate-initialDate)+ " years! \n Press Space to restart.",true);
            gamePaused = true;
            foreach (var VARIABLE in FindObjectsOfType<Ship>())
            {
                VARIABLE.Pause();
            }
            foreach (var VARIABLE in FindObjectsOfType<Port>())
            {
                VARIABLE.Pause();
            }
        }
        if(gamePaused)return;
        timeCount += Time.deltaTime;
        if (timeCount >= secondsInYear)
        {
            timeCount = 0;
            currentDate += 1;
            UpdateText();
        }
    }

    void UpdateText()
    {
        yearTxt.text = "" + currentDate;
    }
}

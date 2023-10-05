using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    static UI instance;
    public static UI i
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<UI>();
            }
            return instance;
        }
    }

    [SerializeField] private TMP_Text notificationBox;
    private float notificationTimeCount = 0;
    private float notificationTimeDuration = 2;
    
    private void Start()
    {
        Notification("DYNASTY STARTS");
    }

    private void Update()
    {
        notificationTimeCount += Time.deltaTime;
        if (notificationTimeCount > notificationTimeDuration)
        {
            notificationTimeCount = 0;
            Notification("");
        }
    }

    public void Notification(string message)
    {
        notificationTimeCount = 0;
        notificationBox.text = message;
        print(message);
    }
}

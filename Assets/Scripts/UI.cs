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
    private float notificationTimeDuration = 1f;
    private bool stays = false;
    [SerializeField] private TMP_Text shipCountTxt;

    private void Start()
    {
        Notification("DYNASTY STARTS");
    }

    private void Update()
    {
        if(stays) return;
        notificationTimeCount += Time.deltaTime;
        if (notificationTimeCount > notificationTimeDuration)
        {
            notificationTimeCount = 0;
            Notification("");
        }
    }

    public void Notification(string message, bool stays = false)
    {
        this.stays = stays;
        if (message.Equals(""))
        {
            notificationBox.gameObject.SetActive(false);
        }
        else
        {
            notificationBox.gameObject.SetActive(true);
        }
        notificationTimeCount = 0;
        notificationBox.text = message;
        print(message);
    }

    public void UpdateShitCount()
    {
        shipCountTxt.text = Ship.shipAmount + "";
    }
}

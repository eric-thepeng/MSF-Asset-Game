using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    static Money instance;
    public static Money i
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<Money>();
            }
            return instance;
        }
    }
    
    [SerializeField] private int amount = 0;
    [SerializeField] private TMP_Text moneyUI;

    private void Start()
    {
        UpdateUI();
    }

    public bool spendMoney(int amount)
    {
        if (this.amount < amount) return false;
        this.amount -= amount;
        UpdateUI();
        return true;
    }

    public void GainMoney(int amount)
    {
        this.amount += amount;
        UpdateUI();
    }

    public void Delivery()
    {
        GainMoney(1);
    }

    void UpdateUI()
    {
        moneyUI.text = "" + amount;
    }

    public int GetAmount()
    {
        return amount;
    }
}

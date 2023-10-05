using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Port : MonoBehaviour
{
    public static List<Port> allPorts = new List<Port>();
    
    [SerializeField] private TMP_Text priceTxt, shipAmountTxt, cargosTxt;
    [SerializeField] private int cargos = 3;
    [SerializeField] private float cargoTime = 1;

    [SerializeField] private GameObject ship;


    private float timeCounter = 0;
    private int boatAmount = 0;

    private void Awake()
    {
        allPorts.Add(this);
    }

    private void Start()
    {
        UpdateInfo();
    }

    private void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= cargoTime)
        {
            cargos++;
            timeCounter = 0;
            UpdateInfo();
        }
    }

    void BuyBoat()
    {
        if (Money.i.spendMoney(GetBoatPrice()))
        {
            UI.i.Notification("Purchase Successful");
            boatAmount += 1;
            UpdateInfo();
            GameObject newShip = Instantiate(ship);
            newShip.GetComponent<Ship>().Born(this);
            newShip.transform.position = transform.position;
        }
        else
        {
            UI.i.Notification("You Are Broke");
        }
    }
    
    int GetBoatPrice()
    {
        return boatAmount * 2 + 1;
    }

    void UpdateInfo()
    {
        //info.text = "Boat Amount: " + boatAmount + "\n Boat Price: " + GetBoatPrice() + "\n Cargos Left: " + cargos;
        priceTxt.text = ""+GetBoatPrice();
        cargosTxt.text = ""+ cargos;
        shipAmountTxt.text = "" + boatAmount;

    }

    private void OnMouseUpAsButton()
    {
        BuyBoat();
    }

    public bool PickUpCargo()
    {
        if (cargos <= 0) return false;
        cargos--;
        UpdateInfo();
        return true;
    }
}

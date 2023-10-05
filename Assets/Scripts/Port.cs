using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Port : MonoBehaviour
{
    public static List<Port> allPorts = new List<Port>();
    
    [SerializeField] private TMP_Text priceTxt, shipAmountTxt, cargosTxt, secTxt;
    [SerializeField] private int cargos = 3;
    [SerializeField] private float cargoTime = 1;

    [SerializeField] private GameObject ship;


    private float timeCounter = 0;
    private int boatAmount = 0;

    private bool paused = false;

    private void Awake()
    {
        allPorts = new List<Port>();
        
    }

    private void Start()
    {
        allPorts.Add(this);
        UpdateInfo();
        secTxt.text = "" + cargoTime;
    }

    private void Update()
    {
        if(paused) return;
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
            UI.i.Notification("PURCHASE SUCCESSFUL");
            boatAmount += 1;
            UpdateInfo();
            GameObject newShip = Instantiate(ship);
            newShip.GetComponent<Ship>().Born(this);
            newShip.transform.position = transform.position;
            GameObject sprite = GetComponentInChildren<SpriteRenderer>().gameObject;
            sprite.transform.localScale = sprite.transform.localScale + new Vector3(0.02f, 0.02f, 0.02f);
        }
        else
        {
            UI.i.Notification("YOU ARE BROKE");
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

    public void Pause()
    {
        paused = true;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ship : MonoBehaviour
{
    
    
    
    private Port homePort;
    private Port targetPort;
    private float speed = 0.3f;
    private int floor = 0;

    public static int shipAmount = 0;

    public enum State
    {
        Waiting,
        SailOff,
        HeadHome,
        Paused
    }

    public State state;

    public void Born(Port homePort)
    {
        this.homePort = homePort;
        state = State.Waiting;
        GetComponentInChildren<TMP_Text>().text = homePort.gameObject.name;
        transform.position = homePort.transform.position;
        floor = homePort.GetFloor();
        shipAmount += 1;
        UI.i.UpdateShitCount();
    }

    private void Update()
    {
        
        if (state == State.Waiting)
        {
            if (homePort.PickUpCargo())
            {
                state = State.SailOff;
                do
                {
                    targetPort = Port.allPorts[Random.Range(0, Port.allPorts.Count)];
                } while (targetPort == homePort);
            }
        }else if (state == State.SailOff)
        {
            Move();
        }else if (state == State.HeadHome)
        {
            Move();
        }
    }

    void Move()
    {
        if (state == State.HeadHome)
        {
            transform.position += (homePort.transform.position - transform.position).normalized * speed * Time.deltaTime;
            if ((homePort.transform.position - transform.position).magnitude <= 0.05f)
            {
                state = State.Waiting;
            }
        }else if (state == State.SailOff)
        {
            transform.position += (targetPort.transform.position - transform.position).normalized * speed * Time.deltaTime;
            if ((targetPort.transform.position - transform.position).magnitude <= 0.05f)
            {
                Money.i.Delivery();
                state = State.HeadHome;
            }
        }
    }

    public void Pause()
    {
        state = State.Paused;
    }
}


public class ShipState
{
    public Location targetLocation;
    public ShipState()
    {
        
    }
}
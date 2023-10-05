using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ship : MonoBehaviour
{
    private Port homePort;
    private Port targetPort;
    private float speed = 0.3f;

    public enum State
    {
        Waiting,
        SailOff,
        HeadHome
    }

    public State state;

    public void Born(Port homePort)
    {
        this.homePort = homePort;
        state = State.Waiting;
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
    /*

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("collider" + other.gameObject.name);
        Port collisionPort = other.gameObject.GetComponent<Port>();
        if(collisionPort == null) return;
        
        if (state == State.SailOff)
        {
            if (collisionPort == targetPort)
            {
                Money.i.Delivery();
                state = State.HeadHome;
            }
        }else if (state == State.HeadHome)
        {
            if (collisionPort == homePort)
            {
                state = State.Waiting;
            }
        }
    }*/
}

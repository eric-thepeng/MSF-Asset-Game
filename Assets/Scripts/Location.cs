using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    [SerializeField]private int floor;

    public int GetFloor() { return floor; }
    public Vector3 GetPosition() { return transform.position; }
}

﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{


    private void Start()
    {
        Debug.Log("start");

    }

    

    private void OnTriggerStay(Collider other)
    {
        GameObject trigerObject = other.gameObject;
        if (((trigerObject.name.Equals("ClampBottom") || trigerObject.name.Equals("ClampTop")) && gameObject.name.Equals("ClampTurret")) || ((gameObject.name.Equals("ClampBottom") || gameObject.name.Equals("ClampTop")) && trigerObject.name.Equals("ClampTurret")))
        {

        }
        else if (((trigerObject.name.Equals("Shoulder")) && gameObject.name.Equals("Turret"))||((gameObject.name.Equals("Shoulder")) && trigerObject.name.Equals("Turret")))
        {

        }
        else if (((trigerObject.name.Equals("Shoulder")) && gameObject.name.Equals("Elbow")) || ((gameObject.name.Equals("Shoulder")) && trigerObject.name.Equals("Elbow")))
        {

        }
        else if (((trigerObject.name.Equals("Elbow")) && gameObject.name.Equals("Wrist")) || ((gameObject.name.Equals("Elbow")) && trigerObject.name.Equals("Wrist")))
        {

        }
        else if (((trigerObject.name.Equals("Wrist")) && gameObject.name.Equals("ClampTurret")) || ((gameObject.name.Equals("Wrist")) && trigerObject.name.Equals("ClampTurret")))
        {

        }
        else if (((trigerObject.name.Equals("Turret")) && gameObject.name.Equals("TurretBody")) || ((gameObject.name.Equals("Turret")) && trigerObject.name.Equals("TurretBody")))
        {

        }
        else if (((trigerObject.name.Equals("Body")) && gameObject.name.Equals("TurretBody")) || ((gameObject.name.Equals("Body")) && trigerObject.name.Equals("TurretBody")))
        {

        }
        else
        {
            Debug.Log(other.gameObject.name + " ile " + gameObject.name + " Çarpışıyor");

        }
    }
}
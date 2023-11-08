using Assets.Scripts.RobotLimit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetection : MonoBehaviour,ICollisionHandler
{
    public bool isLimit { get; private set; }

    GameObject[] trigerObjects;
    GameObject[] thisGameObjects;
    CollisionHandler collisionHandler;
    private void Start()
    {
        isLimit = false;
        collisionHandler = new CollisionHandler(this);
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject trigerObject = other.gameObject;   
        collisionHandler.HandleCollision(true,trigerObject.name, gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject trigerObject = other.gameObject;
        collisionHandler.HandleCollision(false , trigerObject.name, gameObject.name);           
    }
    private void changeColor(GameObject[] gameObjects , Color color)
    {
        foreach (GameObject obj in gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = color;
            }

        }
    }

    public void HandleCollision(bool isStay, string object1, string object2)
    {

        trigerObjects = GameObject.FindObjectsOfType<GameObject>().Where(obj => obj.name == object1).ToArray();
        thisGameObjects = GameObject.FindObjectsOfType<GameObject>().Where(obj => obj.name == object2).ToArray();
        if (isStay)
        {
            isLimit = true;
            changeColor(trigerObjects, Color.red);
            changeColor(thisGameObjects, Color.red);
        }
        else
        {
            isLimit = false;

            changeColor(trigerObjects, Color.black);
            changeColor(thisGameObjects, Color.black);
        }
    }
}

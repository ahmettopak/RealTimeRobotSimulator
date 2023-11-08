using Assets.Scripts.RobotLimit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler
{
    private Dictionary<string, List<string>> collisionMap;
    ICollisionHandler collisionHandler;
    public CollisionHandler(ICollisionHandler collisionHandler)
    {
        this.collisionHandler = collisionHandler;   
        collisionMap = new Dictionary<string, List<string>>();
        AddCollisionPairs();

    }
    private void AddCollisionPairs()
    {
        AddCollisionPair("ClampBottom", "ClampTurret");
        AddCollisionPair("ClampBottom", "Elbow");
        AddCollisionPair("ClampTop", "ClampTurret");
        AddCollisionPair("ClampTop", "Elbow");
        AddCollisionPair("Shoulder", "Turret");
        AddCollisionPair("Shoulder", "Elbow");
        AddCollisionPair("Elbow", "Wrist");
        AddCollisionPair("Wrist", "ClampTurret");
        AddCollisionPair("Turret", "Body");
        AddCollisionPair("Elbow", "PtzBody");
        AddCollisionPair("PtzCamera", "PtzBody");
    }

    private void AddCollisionPair(string object1, string object2)
    {
        if (!collisionMap.ContainsKey(object1))
        {
            collisionMap[object1] = new List<string>();
        }
        collisionMap[object1].Add(object2);

        if (!collisionMap.ContainsKey(object2))
        {
            collisionMap[object2] = new List<string>();
        }
        collisionMap[object2].Add(object1);
    }

    public void HandleCollision(bool isStay , string object1, string object2)
    {
        if (collisionMap.TryGetValue(object1, out List<string> possibleCollisions) && possibleCollisions.Contains(object2) ||
            collisionMap.TryGetValue(object2, out possibleCollisions) && possibleCollisions.Contains(object1))
        {

            //Assembly
            //Debug.Log($"{object1} is colliding with {object2}");
        }
        else
        {

            //Assembly
            //Debug.Log("1111111111111111111");

            if (!object1.Equals(object2))
            {
                //islimit true
                Debug.Log($"{object1} is colliding with {object2}");
                collisionHandler.HandleCollision(isStay , object1, object2);

            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LearnedMove : MonoBehaviour
{

    public GameObject turret;
    public GameObject shoulder;
    public GameObject elbow;
    public GameObject wrist;
    public GameObject clampTurret;
    public GameObject clampBottom;
    public GameObject clampTop;
    public GameObject frontPal;
    public GameObject backPal;

    [SerializeField] private bool isLearnedMove = false;

    [SerializeField] private int frontPalDestinationPositon = 0;
    [SerializeField] private int backPalDestinationPositon = 0;
    [SerializeField] private int turretDestinationPositon = 0;
    [SerializeField] private int shoulderlDestinationPositon = 0;
    [SerializeField] private int elbowDestinationPositon = 0;
    [SerializeField] private int wristDestinationPositon = 0;
    [SerializeField] private int clampDestinationPositon = 0;
    [SerializeField] private int clampTurretDestinationPositon = 0;
    [SerializeField] private int tolerance = 1;
    [SerializeField] private float speed = 5;

    private SavedPosition parkPosition;
    private SavedPosition firePosition;
    private SavedPosition vehiclePosition;
    private SavedPosition customPosition;


    public int selectedIndex = 0;

    private GameObject[] movementOrder;
    private 

    int dir = 1;

    void Start()
    {
        movementOrder = new GameObject[dir];
        parkPosition = new SavedPosition(90,90,0,0,0,180,0,0);
        vehiclePosition = new SavedPosition(0, 0, 0, 200, 100, 0, 50, 0);
        firePosition = new SavedPosition(0, 0, 0, 100, 40, 15, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (isLearnedMove)
        {

            switch (selectedIndex)
            {

                case 0:
                    customPosition = new SavedPosition(frontPalDestinationPositon, 
                        backPalDestinationPositon,
                        turretDestinationPositon,
                        shoulderlDestinationPositon,
                        elbowDestinationPositon,
                        wristDestinationPositon,
                        clampDestinationPositon,
                        clampTurretDestinationPositon);
                    goToSavedPose(customPosition);
                    break;
                case 1:
                    goToSavedPose(parkPosition); break;
                case 2:
                    goToSavedPose(vehiclePosition); break;
                case 3:
                    goToSavedPose(firePosition); break;
                default:
                    break;
            }
            
        }
    }

    private bool goToPose(GameObject targetObject, int destinationPose)
    {
        if (!targetObject.GetComponent<CollisionDetection>().isLimit)
        {
            
        
            int diff = (int)(destinationPose - targetObject.transform.localEulerAngles.z);
            if (Math.Abs(diff) < tolerance)
            {
                return true;
            }
            else
            {
                if (diff > 0)
                {
                    moveObject(targetObject, speed);  
                }
                else
                {
                    moveObject(targetObject, -speed);


                }
                return false;

            }

        }
        else
        {
            return false;
        }
    }
    private bool goToPoseSafety(GameObject targetObject, int destinationPose)
    {

        int diff = (int)(destinationPose - targetObject.transform.localEulerAngles.z);
        if (Math.Abs(diff) < tolerance)
        {
            return true;
        }


        if (targetObject.GetComponent<CollisionDetection>().isLimit)
        {

                if (diff > 0)
                {
                    moveObject(targetObject, -speed);
                }
                else
                {
                    moveObject(targetObject, speed);

                }
        }
        else
        {
            if (diff > 0)
            {
                moveObject(targetObject, speed);
            }
            else
            {
                moveObject(targetObject, -speed);

            }
        }
        return false;

    }
    private void goToSavedPose(SavedPosition savedPosition)
    {


        if (goToPoseSafety(turret, savedPosition.turretAngle))
        {

            if (goToPoseSafety(shoulder, savedPosition.shoulderlAngle))
            {
                if (goToPoseSafety(elbow, savedPosition.elbowAngle))
                {
                    if (goToPoseSafety(wrist, savedPosition.wristAngle))
                    {
                        if (goToPoseSafety(clampTop, savedPosition.clampAngle) && goToPoseSafety(clampBottom, savedPosition.clampAngle))
                        {
                            if (goToPoseSafety(clampTurret, savedPosition.clampTurretAngle))
                            {

                            }
                        }
                    }
                }
            }
        }
        //;
        //goToPoseSafety(wrist, savedPosition.wristAngle);
        //goToPoseSafety(clampTop, savedPosition.clampAngle);
        //goToPoseSafety(clampBottom, savedPosition.clampAngle);
        //goToPoseSafety(clampTurret, savedPosition.clampTurretAngle);
        //goToPoseSafety(frontPal, savedPosition.frontPalAngle);
        //goToPoseSafety(backPal, savedPosition.backPalAngle);
    }

    private void moveObject(GameObject gameObject, float speed)
    {
        gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, gameObject.transform.localEulerAngles.z + speed/10);
    }
}

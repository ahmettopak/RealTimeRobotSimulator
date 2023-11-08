using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManuelRobotController : MonoBehaviour
{

    [Range(0f, 360f)]
    public float turretSliderValue;

    [Range(0f, 180f)]
    public float shoulderSliderValue;

    [Range(0f, 270f)]
    public float elbowSliderValue;

    [Range(0f, 360f)]
    public float wristSliderValue;

    [Range(0f, 360f)]
    public float clampTurretSliderValue;

    [Range(0f, 100f)]
    public float clampSliderValue;

    [Range(0f, 360f)]
    public float frontPalSliderValue;

    [Range(0f, 360f)]
    public float backPalSliderValue;


    public Transform turret;
    public Transform shoulder;
    public Transform elbow;
    public Transform wrist;
    public Transform clampTurret;
    public Transform clampBottom;
    public Transform clampTop;
    public Transform frontPal;
    public Transform backPal;

    void Start()
    {
        
    }

    
    void Update()
    {
        turret.localRotation = Quaternion.Euler(0f, 0f, turretSliderValue);
        shoulder.localRotation = Quaternion.Euler(0f, 0f, shoulderSliderValue);
        elbow.localRotation = Quaternion.Euler(0f, 0f, elbowSliderValue);
        wrist.localRotation = Quaternion.Euler(0f, 0f, wristSliderValue);
        clampTurret.localRotation = Quaternion.Euler(0f, 0f, clampTurretSliderValue);
        clampBottom.localRotation = Quaternion.Euler(0f, 0f, clampSliderValue);
        clampTop.localRotation = Quaternion.Euler(0f, 0f, clampSliderValue);
        frontPal.localRotation = Quaternion.Euler(0f, 0f, frontPalSliderValue);
        backPal.localRotation = Quaternion.Euler(0f, 0f, backPalSliderValue);
    }

    
}

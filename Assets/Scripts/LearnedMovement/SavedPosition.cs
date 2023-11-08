using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedPosition
{
    public int frontPalAngle { get; private set; } = 0;
    public int backPalAngle { get; private set; } = 0;
    public int turretAngle { get; private set; } = 0;
    public int shoulderlAngle { get; private set; } = 0;
    public int elbowAngle { get; private set; } = 0;
    public int wristAngle { get; private set; } = 0;
    public int clampAngle { get; private set; } = 0;
    public int clampTurretAngle { get; private set; } = 0;
    public SavedPosition(int frontPalAngle, int backPalAngle, int turretAngle, int shoulderlAngle, int elbowAngle, int wristAngle, int clampAngle, int clampTurretAngle)
    {
        this.frontPalAngle = frontPalAngle;
        this.backPalAngle = backPalAngle;
        this.turretAngle = turretAngle;
        this.shoulderlAngle = shoulderlAngle;
        this.elbowAngle = elbowAngle;
        this.wristAngle = wristAngle;
        this.clampAngle = clampAngle;
        this.clampTurretAngle = clampTurretAngle;
    }
}

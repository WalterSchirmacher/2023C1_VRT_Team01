using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedLeverController : MonoBehaviour
{
    HingeJoint hinge;

    // public GameObject boat;
    public GameObject oceanScenery;

    float maxAngle, minAngle;

    public float maxShipSpeed;
    public float shipSpeed;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        maxAngle = 60f;
        minAngle = 0f;
    }

    void Update()
    {
        // find fraction of allowed rotation that the player has used
        float angleFraction = hinge.angle / maxAngle - minAngle;

        // find the speed of the ship based on max allowed speed and angle fraction
        shipSpeed = maxShipSpeed * angleFraction;

        // move ocean scenery towards the ship an amount based on angle fraction
        // ** Vector direction may need to change based on direction the ship is facing **
        oceanScenery.transform.Translate(-angleFraction / 100, 0, 0, Space.World);
    }
}

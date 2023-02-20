using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedLeverController : MonoBehaviour
{
    HingeJoint hinge;

    public GameObject boat;
    public GameObject speedText;

    float maxAngle, minAngle;

    public float maxBoatSpeed;
    public float boatSpeed;
    public string defaultSpeedText = "Speed: ";

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

        boatSpeed = maxBoatSpeed * angleFraction;

        // move boat forward an amount based on player rotation input
        boat.transform.Translate(angleFraction / 100, 0, 0);
    }
}

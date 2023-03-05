using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedLeverController : MonoBehaviour
{
    HingeJoint hinge;

    public GameObject oceanScenery;

    public float angleFraction;
    public float shipSpeed;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    void Update()
    {
        // find fraction of allowed rotation that the player has used
        angleFraction = hinge.angle / (hinge.limits.max - hinge.limits.min);

        // move ocean scenery towards the ship an amount based on angle fraction and ship speed
        if (hinge.angle > 10 || hinge.angle < -10)
        {
            oceanScenery.transform.Translate(0, 0, angleFraction * shipSpeed * Time.deltaTime, Space.World);
        }
    }
}

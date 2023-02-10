using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLeverController : MonoBehaviour
{
    HingeJoint hinge;
    public GameObject boat;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    void Update()
    {
        // find fraction of allowed rotation that the player has used
        float angleFraction = hinge.angle / hinge.limits.max;

        // move boat forward an amount based on player rotation input
        boat.transform.Translate(angleFraction / 100, 0, 0);
    }
}

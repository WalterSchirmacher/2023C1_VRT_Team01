using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    HingeJoint hinge;
    public float storedDegrees;
    float lastFramesAngle;
    // public GameObject boat;
    public GameObject oceanScenery;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    void Update()
    {
        // find how much the wheel has rotated since last frame
        float differenceInAngle = hinge.angle - lastFramesAngle;

        // adjust for changes greater than 300 (when moving from 180 to -180 or vice versa)
        if (differenceInAngle > 300f)
        {
            differenceInAngle -= 360f;
        }
        if(differenceInAngle < -300f)
        {
            differenceInAngle += 360f;
        }

        // add the change in rotation to total degrees rotated
        storedDegrees += differenceInAngle;

        // rotate the boat according to the change in wheel rotation
        oceanScenery.transform.Rotate(0, differenceInAngle / 50, 0);

        // set last frame's wheel angle equal to this frame's angle for use in the next frame
        lastFramesAngle = hinge.angle;
    }
}

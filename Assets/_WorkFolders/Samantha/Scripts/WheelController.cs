using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    HingeJoint hinge;

    public GameObject islands;
    public GameObject flyingDutchman;

    float skyboxRotation;
    float lastFramesAngle;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    void Update()
    {
        // find how much the wheel has rotated since last frame
        float differenceInAngle = hinge.angle - lastFramesAngle;

        // adjust for changes greater than 320 (when moving from 180 to -180 or vice versa)
        if (differenceInAngle > 320f)
        {
            differenceInAngle -= 360f;
        }
        if(differenceInAngle < -320f)
        {
            differenceInAngle += 360f;
        }

        // rotate the islands according to the change in wheel rotation
        islands.transform.Rotate(0, differenceInAngle / 75f, 0);

        // rotate the Dutchman
        flyingDutchman.transform.Rotate(0, differenceInAngle / 35f, 0);

        // rotate the skybox also?
        if(differenceInAngle > 1)
        {
            skyboxRotation = RenderSettings.skybox.GetFloat("_Rotation");
            RenderSettings.skybox.SetFloat("_Rotation", skyboxRotation - Time.deltaTime * 2.0f);
        }
        if(differenceInAngle < -1)
        {
            skyboxRotation = RenderSettings.skybox.GetFloat("_Rotation");
            RenderSettings.skybox.SetFloat("_Rotation", skyboxRotation + Time.deltaTime * 2.0f);
        }

        // set last frame's wheel angle equal to this frame's angle for use in the next frame
        lastFramesAngle = hinge.angle;
    }
}

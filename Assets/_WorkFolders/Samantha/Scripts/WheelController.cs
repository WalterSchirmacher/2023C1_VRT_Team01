using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    HingeJoint hinge;
    JointSpring spring;
    public float storedDegrees;
    float lastFramesAngle;
    public float minDegrees, maxDegrees;
    public GameObject boat;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        //spring = hinge.spring;

    }

    // Update is called once per frame
    void Update()
    {
        float differenceInAngle = hinge.angle - lastFramesAngle;

        if (differenceInAngle > 300f)
        {
            differenceInAngle -= 360f;
        }
        if(differenceInAngle < -300f)
        {
            differenceInAngle += 360f;
        }

        storedDegrees += differenceInAngle;

        boat.transform.Rotate(0, differenceInAngle, 0);

        //spring.targetPosition = hinge.angle;

        lastFramesAngle = hinge.angle;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLever : MonoBehaviour
{

    HingeJoint hinge;
    public float leverOutput;
    public float minValue, maxValue;

    public float startingValue;
    public float outputValue;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();

        if(startingValue >= minValue && startingValue <= maxValue)
        {
            float rangeFraction = (startingValue - minValue) / (maxValue - minValue);
            float degreeRotation = hinge.limits.min + (hinge.limits.max - hinge.limits.min) * rangeFraction;
            Vector3 worldSpaceHIngeAxis = transform.TransformDirection(hinge.axis);
            transform.rotation = Quaternion.AngleAxis(degreeRotation, worldSpaceHIngeAxis) * transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        outputValue = (hinge.angle - hinge.limits.min) / (hinge.limits.max - hinge.angle);
        float betweenZeroAndOne = (hinge.angle - hinge.limits.min) / (hinge.limits.max - hinge.limits.min);
        leverOutput = minValue + (maxValue - minValue) * betweenZeroAndOne;

        Debug.Log("Lever output is: " + leverOutput);
        Debug.Log("Hinge Angle is: " + hinge.angle);
        Debug.Log("Output value is: " + outputValue);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class IonLever : MonoBehaviour
{
    HingeJoint hinge;
    public float leverOutput;
    public float minValue, maxValue;

    public float startingValue;
    public bool canonActivated;
    public UnityEvent onActivation;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        if(startingValue >= minValue && startingValue <= maxValue)
        {
            float rangeFraction = (startingValue - minValue) / (maxValue - minValue);
            float degreeRotation = hinge.limits.min + (hinge.limits.max - hinge.limits.min) * rangeFraction;
            Vector3 worldSpaceHingeAxis = transform.TransformDirection(hinge.axis);
            transform.rotation = Quaternion.AngleAxis(degreeRotation, worldSpaceHingeAxis) * transform.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float betweenZeroAndOne = (hinge.angle - hinge.limits.min) / (hinge.limits.max - hinge.limits.min);
        leverOutput = minValue + (maxValue - minValue) * betweenZeroAndOne;
   //     Debug.Log("Lever Output is " + leverOutput);

        if(leverOutput > (maxValue - 5) && !canonActivated)
        {
            canonActivated = true;
            StartActivation();
        }
    }

    public void StartActivation()
    {
        onActivation.Invoke();
    }
}

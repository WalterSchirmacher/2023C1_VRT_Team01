using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotation : MonoBehaviour
{
    public GameObject steeringWheel;
    HingeJoint wheelHinge;
    float lastFramesAngle;
    float angleFraction;

    // Start is called before the first frame update
    void Start()
    {
        wheelHinge = steeringWheel.GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        float differenceInAngle = wheelHinge.angle - lastFramesAngle;
        angleFraction = differenceInAngle / (wheelHinge.limits.max - wheelHinge.limits.min);

        if(differenceInAngle > 1)
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * angleFraction);
        }

        lastFramesAngle = wheelHinge.angle;
    }
}

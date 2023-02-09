using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLeverController : MonoBehaviour
{
    HingeJoint hinge;
    public float lastFramesAngle;
    public GameObject boat;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        float differenceInAngle = hinge.angle - lastFramesAngle;

        if(differenceInAngle > 5)
        {
            boat.transform.Translate(.1f, 0, 0);
        }
    }
}

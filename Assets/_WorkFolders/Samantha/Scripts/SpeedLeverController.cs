using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedLeverController : MonoBehaviour
{
    HingeJoint hinge;

    public GameObject oceanScenery;
    public GameObject frontCD;
    public GameObject rearCD;

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

        // when lever is pulled, check for collisions and move islands in an allowed direction
        if (hinge.angle > 5)
        {
            if (!frontCD.GetComponent<IslandCollisionHandler>().collided)
            {
                oceanScenery.transform.Translate(0, 0, angleFraction * shipSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                Debug.Log("YOU RAN AGROUND!");
            }
        }
        if (hinge.angle < -5)
        {
            if (!rearCD.GetComponent<IslandCollisionHandler>().collided)
            {
                oceanScenery.transform.Translate(0, 0, angleFraction * shipSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                Debug.Log("YOU RAN AGROUND!");
            }
        }
    }
}

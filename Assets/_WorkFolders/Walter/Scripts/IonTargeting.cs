using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IonTargeting : MonoBehaviour
{
    public enum MoveDirection { ForwardBack, LeftRight };
    public MoveDirection direction;
    public IonCanonFire Cannon;
    public PowerReceiver powerReceiver;
    public GameObject targetObject, backBlock, forwardBlock, leftBlock, rightBlock;
    public AudioSource audioSource;
    HingeJoint hinge;
    public float leverOutput;
    [Range(-5,-15)]
    public int stopMoveLow = -5;
    [Range(5,15)]
    public int stopMoveHigh = 5;
    private float minValue, maxValue;
    private Vector3 targetStart;
    [HideInInspector]
    public bool backHit = false, forwardHit = false, leftHit = false, rightHit = false;

    public bool moveObj = false;
    private float stopLow, stopHigh;
    private float xLimit, xMax, zLimit, zMax;
    private GameObject fireButton;

    // Start is called before the first frame update
    void Start()
    {
        targetObject.SetActive(false);
        hinge = GetComponent<HingeJoint>();
        fireButton = powerReceiver.pushButton;
        minValue = hinge.limits.min;
        maxValue = hinge.limits.max;
        targetStart = transform.position;
        stopLow = (float)stopMoveLow;
        stopHigh = (float)stopMoveHigh;
        xLimit = backBlock.transform.position.x;
        xMax = forwardBlock.transform.position.x;
        zLimit = leftBlock.transform.position.z;
        zMax = rightBlock.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveObj && direction == MoveDirection.ForwardBack)
        {
            UpdatePosForwardBack();
        } else if (moveObj && direction == MoveDirection.LeftRight)
        {
            UpdatePosleftRight();
        }
    }

    public void StartMoving()
    {
        moveObj = true;
        Cannon.MakeTransparent();
        if(!targetObject.activeInHierarchy)
        {
            targetObject.SetActive(true);
        }
        if (!fireButton.activeInHierarchy)
        {
            fireButton.SetActive(true);
        }
    }

    public void StopMoving()
    {
        moveObj = false;
        Cannon.MakeVisible();
    }

    private void UpdatePosForwardBack()
    {
        float betweenZeroAndOne = (hinge.angle - hinge.limits.min) / (hinge.limits.max - hinge.limits.min);
        leverOutput = math.round(minValue + (maxValue - minValue) * betweenZeroAndOne);

      if(leverOutput < stopLow || leverOutput > stopHigh)
      {
            float posNeg = Mathf.Sign(leverOutput);

            if (posNeg == 1)
            {

                // Move Back towards Main Pirate Ship
                // Check if not moving back over the limit, otherwise reverse it slightly to keep it out of the buffer.
                if (targetObject.transform.position.x < xLimit)
                {
                    targetObject.transform.position += Vector3.right * Time.deltaTime;
                }
                else
                {
                    targetObject.transform.position -= Vector3.right * Time.deltaTime;
                    if(!audioSource)
                    {
                        audioSource.Play();
                    }
                    
                }
             //   Debug.Log("Moving Back " + targetObject.transform.position.x);
            }
            else if (posNeg == -1)
            {
                // Move Forward towards Enemy Pirate Ship
                if (targetObject.transform.position.x > xMax)
                {
                    targetObject.transform.position += Vector3.left * Time.deltaTime;
                }
                else
                {
                    targetObject.transform.position -= Vector3.left * Time.deltaTime;
                    if (!audioSource)
                    {
                        audioSource.Play();
                    }
                } 
            }
            else
            {
                Debug.Log("Not Moving");
            }
        }
    }

    private void UpdatePosleftRight()
    {
        float betweenZeroAndOne = (hinge.angle - hinge.limits.min) / (hinge.limits.max - hinge.limits.min);
        leverOutput = math.round(minValue + (maxValue - minValue) * betweenZeroAndOne);

       if (leverOutput < stopLow || leverOutput > stopHigh)
      {
            float posNeg = Mathf.Sign(leverOutput);

            if (posNeg == 1)
            {
                //Moving target right
                if (targetObject.transform.position.z < zMax)
                {
                    targetObject.transform.position += Vector3.forward * Time.deltaTime;
                } else
                {
                    targetObject.transform.position -= Vector3.forward * Time.deltaTime;
                    if (!audioSource)
                    {
                        audioSource.Play();
                    }
                }
            }
            else if (posNeg == -1)
            {
                // Moving target left
                if (targetObject.transform.position.z > zLimit)
                {
                    targetObject.transform.position += Vector3.back * Time.deltaTime;
                }
                else
                {
                    targetObject.transform.position -= Vector3.back * Time.deltaTime;
                    if (!audioSource)
                    {
                        audioSource.Play();
                    }
                }

            }
            else
            {
                Debug.Log("Not Moving");
            }
     }
    }
}


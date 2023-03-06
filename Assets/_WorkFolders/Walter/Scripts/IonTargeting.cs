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
    private Vector3 currentPos;
    public Vector3 targetPos;
    public string isPosNeg;

    [HideInInspector]
    public bool backHit = false, forwardHit = false, leftHit = false, rightHit = false;

    public bool moveObj = false;
    public bool playErr = false;
    private float stopLow, stopHigh;
    private float xLimit, xMax, zLimit, zMax;
    private GameObject fireButton;
    public IonTargetingNewSync sync;

    private void Awake()
    {
        sync = GetComponent<IonTargetingNewSync>();
    }

    // Start is called before the first frame update
    void Start()
    {
        targetObject.SetActive(false);
        hinge = GetComponent<HingeJoint>();
        fireButton = powerReceiver.pushButton;
        minValue = hinge.limits.min;
        maxValue = hinge.limits.max;
        currentPos = transform.position;
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
        UpdateMoveObj();
        sync.SendOutNewUpdate();
        Debug.Log("canon target " + targetObject.transform.position);
    }

    public void StopMoving()
    {
        moveObj = false;
        UpdateMoveObj();
        sync.SendOutNewUpdate();
    }

    public void UpdateMoveObj()
    {
        
        if (moveObj)
        {
            Cannon.MakeTransparent();
            if (!targetObject.activeInHierarchy)
            {
                targetObject.SetActive(true);
            }
            if (!fireButton.activeInHierarchy)
            {
                fireButton.SetActive(true);
            }
        } else
        {
            Cannon.MakeVisible();
        }
    }

    public void UpdateTargetPos()
    {
        if(moveObj)
        {
            if(isPosNeg == "+")
            {
                targetObject.transform.position += targetPos;
            } else
            {
                targetObject.transform.position -= targetPos;
            }
            
            if (playErr)
            {
                playErr = false;
                if (!audioSource)
                {
                    audioSource.Play();
                }
            }
        }
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
                targetPos = Vector3.right * Time.deltaTime;
                if (targetObject.transform.position.x < xLimit)
                {
                    isPosNeg = "+";
                    playErr = false; 
                }
                else
                {
                    isPosNeg = "-";
                    playErr = true;
                }
                UpdateTargetPos();
                sync.SendOutNewUpdate();
                //   Debug.Log("Moving Back " + targetObject.transform.position.x);
            }
            else if (posNeg == -1)
            {
                // Move Forward towards Enemy Pirate Ship
                targetPos = Vector3.left * Time.deltaTime;
                if (targetObject.transform.position.x > xMax)
                {
                    isPosNeg = "+";
                    playErr = false;
                }
                else
                {
                    isPosNeg = "-";
                    playErr = true;
                }
                UpdateTargetPos();
                sync.SendOutNewUpdate();
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
                targetPos = Vector3.forward * Time.deltaTime;
                if (targetObject.transform.position.z < zMax)
                {
                    isPosNeg = "+";
                    playErr = false;
                }
                else
                {
                    isPosNeg = "-";
                    playErr = true;
                }
                UpdateTargetPos();
                sync.SendOutNewUpdate();
            }
            else if (posNeg == -1)
            {
                // Moving target left
                targetPos = Vector3.back * Time.deltaTime;
                if (targetObject.transform.position.z > zLimit)
                {
                    isPosNeg = "+";
                    playErr = false;
                }
                else
                {
                    isPosNeg = "-";
                    playErr = true;
                }
                UpdateTargetPos();
                sync.SendOutNewUpdate();
            }
            else
            {
                Debug.Log("Not Moving");
            }
     }
    }
}


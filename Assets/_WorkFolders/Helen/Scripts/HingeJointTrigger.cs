using UnityEngine;
using UnityEngine.Events;

public class HingeJointTrigger : MonoBehaviour
{
   
    public float angleBetweenThreshold = 1f;
    public HingeJointState hingeJointState = HingeJointState.None;

    
    public UnityEvent OnMinLimitReached;
    public UnityEvent OnMaxLimitReached;

    public enum HingeJointState { Min, Max, None }
    private HingeJoint hinge;

    
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    private void FixedUpdate()
    {
        float angleWithMinLimit = Mathf.Abs(hinge.angle - hinge.limits.min);
        float angleWithMaxLimit = Mathf.Abs(hinge.angle - hinge.limits.max);

        if (angleWithMinLimit < angleBetweenThreshold)
        {
            if (hingeJointState != HingeJointState.Min)
                OnMinLimitReached.Invoke();

            hingeJointState = HingeJointState.Min;
        }

        else if (angleWithMaxLimit < angleBetweenThreshold)
        {
            if (hingeJointState != HingeJointState.Max)
                OnMaxLimitReached.Invoke();

            hingeJointState = HingeJointState.Max;
        }
   
        else
        {
            hingeJointState = HingeJointState.None;
        }
    }
}
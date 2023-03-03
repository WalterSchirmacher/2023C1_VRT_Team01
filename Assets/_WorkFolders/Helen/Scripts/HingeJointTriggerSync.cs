using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class HingeJointTriggerSync : RealtimeComponent<HingeJointTriggerModel>
{

    HingeJointTrigger hingejoint;

    private void Awake()
    {
        hingejoint = GetComponent<HingeJointTrigger>();
    }

    void UpdateLocalHinge() 
    {
        hingejoint.angleBetweenThreshold = model.angleBetweenThreshold;
        //hingejoint.HingeActivate();
        
    }

    void SubscribableUpdateHingeJoint(HingeJointTriggerModel model, float angle)
    {
        UpdateLocalHinge();
    }
    protected override void OnRealtimeModelReplaced(HingeJointTriggerModel previousModel, HingeJointTriggerModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.angleBetweenThresholdDidChange -= SubscribableUpdateHingeJoint;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.angleBetweenThreshold = hingejoint.angleBetweenThreshold;
            }
            currentModel.angleBetweenThresholdDidChange += SubscribableUpdateHingeJoint;
            UpdateLocalHinge(); 
        }
    }

    public void SendOutNewAngle()
    {
        model.angleBetweenThreshold = hingejoint.angleBetweenThreshold;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

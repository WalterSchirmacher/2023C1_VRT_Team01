using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class IonTargetingNewSync : RealtimeComponent<IonTargetingNewModel>
{
    IonTargeting localIonTargeting;

    private void Awake()
    {
        localIonTargeting = GetComponent<IonTargeting>();
    }

    void UpdateLocalIonTarget()
    {
        localIonTargeting.moveObj = model.moveObjShowing;
        localIonTargeting.targetPos = model.targetPosition;
        localIonTargeting.playErr = model.playErrSnd;
        localIonTargeting.UpdateMoveObj();
    }

    void SubscribableUpdateLocalReceiver(IonTargetingNewModel model, bool passBool)
    {
        UpdateLocalIonTarget();
    }

    protected override void OnRealtimeModelReplaced(IonTargetingNewModel previousModel, IonTargetingNewModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.moveObjShowingDidChange -= SubscribableUpdateLocalReceiver;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.moveObjShowing = localIonTargeting.moveObj;
            }
            currentModel.moveObjShowingDidChange += SubscribableUpdateLocalReceiver;
            UpdateLocalIonTarget();
        }
    }
    public void SendOutNewUpdate()
    {
        model.moveObjShowing = localIonTargeting.moveObj;
        model.targetPosition = localIonTargeting.targetPos;
        model.playErrSnd = localIonTargeting.playErr;
    }

}

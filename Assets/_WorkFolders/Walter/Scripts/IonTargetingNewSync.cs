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
        localIonTargeting.isPosNeg = model.posNeg;
        localIonTargeting.UpdateMoveObj();
        localIonTargeting.UpdateTargetPos();
    }

    void SubscribableUpdateLocalReceiver(IonTargetingNewModel model, bool passBool)
    {
        UpdateLocalIonTarget();
    }

    void SubscribableUpdateLocalReceiver2(IonTargetingNewModel model, Vector3 vec)
    {
        UpdateLocalIonTarget();
    }

    void SubscribableUpdateLocalReceiver3(IonTargetingNewModel model, bool morebool)
    {
        UpdateLocalIonTarget();
    }

    void SubscribableUpdateLocalReceiver4(IonTargetingNewModel model, string posnegvall)
    {
        UpdateLocalIonTarget();
    }

    protected override void OnRealtimeModelReplaced(IonTargetingNewModel previousModel, IonTargetingNewModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.moveObjShowingDidChange -= SubscribableUpdateLocalReceiver;
            previousModel.targetPositionDidChange -= SubscribableUpdateLocalReceiver2;
            previousModel.playErrSndDidChange -= SubscribableUpdateLocalReceiver3;
            previousModel.posNegDidChange -= SubscribableUpdateLocalReceiver4;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.moveObjShowing = localIonTargeting.moveObj;
            }
            currentModel.moveObjShowingDidChange += SubscribableUpdateLocalReceiver;
            currentModel.targetPositionDidChange += SubscribableUpdateLocalReceiver2;
            currentModel.playErrSndDidChange += SubscribableUpdateLocalReceiver3;
            currentModel.posNegDidChange += SubscribableUpdateLocalReceiver4;
            UpdateLocalIonTarget();
        }
    }
    public void SendOutNewUpdate()
    {
        model.moveObjShowing = localIonTargeting.moveObj;
        model.targetPosition = localIonTargeting.targetPos;
        model.playErrSnd = localIonTargeting.playErr;
        model.posNeg = localIonTargeting.isPosNeg;
    }

}

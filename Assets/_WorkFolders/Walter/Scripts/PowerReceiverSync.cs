using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PowerReceiverSync : RealtimeComponent<PowerReceiverModel>
{
    PowerReceiver localReceiver;

    private void Awake()
    {
        localReceiver = GetComponent<PowerReceiver>();
    }

    void UpdateLocalReceiver()
    {
        localReceiver.ionPower = model.powerCount;
        localReceiver.UpdatePowerReceiver();
    }

    void SubscribableUpdateLocalReceiver(PowerReceiverModel model, int passPowerCount)
    {
        UpdateLocalReceiver();
    }

    protected override void OnRealtimeModelReplaced(PowerReceiverModel previousModel, PowerReceiverModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.powerCountDidChange -= SubscribableUpdateLocalReceiver;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.powerCount = localReceiver.ionPower;
            }
            currentModel.powerCountDidChange += SubscribableUpdateLocalReceiver;
            UpdateLocalReceiver();
        }
    }

    public void SendOutNewCount()
    {
        model.powerCount = localReceiver.ionPower;
    }
}

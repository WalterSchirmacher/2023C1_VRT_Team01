using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class BatterySync : RealtimeComponent<BatteriesModel> {

    Batteries localBattery;

    private void Awake()
    {
        localBattery = GetComponent<Batteries>();
    }

    void UpdateLocalBattery()
    {
        localBattery.toBeDestroyed = model.blowUp;
        localBattery.BlowUpObj();
    }

    void SubscribableUpdateLocalBattery(BatteriesModel model, bool passedIsShowing)
    {
        UpdateLocalBattery();
    }

    protected override void OnRealtimeModelReplaced(BatteriesModel previousModel, BatteriesModel currentModel)
    {
        if(previousModel != null)
        {
            previousModel.blowUpDidChange -= SubscribableUpdateLocalBattery;
        }

        if(currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.blowUp = localBattery.toBeDestroyed;
            }
            currentModel.blowUpDidChange += SubscribableUpdateLocalBattery;
            UpdateLocalBattery();
        }
    }

    public void SendOutVisibility()
    {
       model.blowUp = localBattery.toBeDestroyed;
 
    }

}

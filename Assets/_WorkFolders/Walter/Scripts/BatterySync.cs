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
        localBattery.isVisible = model.vis;
        localBattery.ChangeVisibility();
    }

    void SubscribableUpdateLocalBattery(BatteriesModel model, bool passedIsShowing)
    {
        UpdateLocalBattery();
    }

    protected override void OnRealtimeModelReplaced(BatteriesModel previousModel, BatteriesModel currentModel)
    {
        if(previousModel != null)
        {
            previousModel.visDidChange -= SubscribableUpdateLocalBattery;
        }

        if(currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.vis = localBattery.isVisible;
            }
            currentModel.visDidChange += SubscribableUpdateLocalBattery;
            UpdateLocalBattery();
        }
    }

    public void SendOutVisibility()
    {
       model.vis = localBattery.isVisible;
 
    }

}

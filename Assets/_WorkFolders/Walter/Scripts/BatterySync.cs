using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class BatterySync : RealtimeComponent<BatterySyncModel> {

    Batteries localBattery;

    private void Awake()
    {
        localBattery = GetComponent<Batteries>();
    }

    void UpdateLocalBattery()
    {
        localBattery.isVisible = model.isShowing;
        localBattery.ChangeVisibility();
    }

    void SubscribableUpdateLocalBattery(BatterySyncModel model, bool passedIsShowing)
    {
        UpdateLocalBattery();
    }

    protected override void OnRealtimeModelReplaced(BatterySyncModel previousModel, BatterySyncModel currentModel)
    {
        if(previousModel != null)
        {
            previousModel.isShowingDidChange -= SubscribableUpdateLocalBattery;
        }

        if(currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.isShowing = localBattery.isVisible;
            }
            currentModel.isShowingDidChange += SubscribableUpdateLocalBattery;
            UpdateLocalBattery();
        }
    }

    public void SendOutNewVisibility()
    {
        model.isShowing = localBattery.isVisible;
    }

}

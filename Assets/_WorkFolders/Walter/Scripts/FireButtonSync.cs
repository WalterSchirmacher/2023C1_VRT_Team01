using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class FireButtonSync : RealtimeComponent<FireButtonModel>
{

    FireButton localFireButton;

    private void Awake()
    {
        localFireButton = GetComponent<FireButton>();
    }

    void UpdateLocalFireButton()
    {
        localFireButton.isFired = model.fireButton;
        if(model.fireButton)
        {
            localFireButton.FireCannon();
        }
     //   localFireButton.UpdateIon();
    }

    void SubscribableUpdateLocalFireButton(FireButtonModel model, bool passedIsFired)
    {
        UpdateLocalFireButton();
    }

    protected override void OnRealtimeModelReplaced(FireButtonModel previousModel, FireButtonModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.fireButtonDidChange -= SubscribableUpdateLocalFireButton;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.fireButton = localFireButton.isFired;
            }
            currentModel.fireButtonDidChange += SubscribableUpdateLocalFireButton;
            UpdateLocalFireButton();
        }
    }
    public void SendOutFireBtnStatus()
    {
        model.fireButton = localFireButton.isFired;

    }

}



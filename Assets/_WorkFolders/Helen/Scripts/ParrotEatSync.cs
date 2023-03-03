using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.XR.Interaction.Toolkit;

public class ParrotEatSync : RealtimeComponent<ParrotEatModel>
{

    ParrotEat parrotEat;

    private void Awake()
    {
        parrotEat = GetComponent<ParrotEat>();
    }

    void UpdateLocalBool()
    {

        parrotEat.isObjectInSocket = model.isObjectInSocket;
        parrotEat.DestroyObject();

    }
       

    void SubscribableUpdateLocalBool(ParrotEatModel previousmodel, bool socket)
    {
        UpdateLocalBool();
    }


    protected override void OnRealtimeModelReplaced(ParrotEatModel previousModel, ParrotEatModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.isObjectInSocketDidChange -= SubscribableUpdateLocalBool;
        }

        if (currentModel != null)
        {

            if (currentModel.isFreshModel)
            {
                currentModel.isObjectInSocket = parrotEat.isActiveAndEnabled;
            }
            currentModel.isObjectInSocketDidChange += SubscribableUpdateLocalBool;
            UpdateLocalBool();
        }
    }

    public void SendOutNewInfo()
    {
        model.isObjectInSocket = parrotEat.isObjectInSocket;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class EnemyShipSync : RealtimeComponent<EnemyShipModel> {

    EnemyShip localEnemyShip;

    // Start is called before the first frame update
    void Awake()
    {
        localEnemyShip = GetComponent<EnemyShip>();
    }

    void UpdateLocalShip()
    {
        localEnemyShip.isHit = model.isHitBool;
        localEnemyShip.fireActive = model.fireActive;
        localEnemyShip.UpdateFire();
    }

    void SubscribableUpdateLocalEnemyShip(EnemyShipModel model, bool passedIsHit)
    {
        UpdateLocalShip();
    }

    protected override void OnRealtimeModelReplaced(EnemyShipModel previousModel, EnemyShipModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.isHitBoolDidChange -= SubscribableUpdateLocalEnemyShip;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.isHitBool = localEnemyShip.isHit;
                currentModel.fireActive = localEnemyShip.fireActive;
            }
            currentModel.isHitBoolDidChange += SubscribableUpdateLocalEnemyShip;
            UpdateLocalShip();
        }
    }

    public void SendOutHitFireInfo()
    {
        model.isHitBool = localEnemyShip.isHit;
        model.fireActive = localEnemyShip.fireActive;

    }
}

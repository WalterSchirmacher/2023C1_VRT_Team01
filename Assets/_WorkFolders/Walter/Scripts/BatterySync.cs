using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class BatterySync : RealtimeComponent<BatterySyncModel> {

    private void UpdateBatteryVisibility()
    {
        gameObject.SetActive(model.isShowing);
    }
}

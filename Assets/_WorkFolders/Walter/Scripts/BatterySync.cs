using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class BatterySync : RealtimeComponent<BatterySyncModel> {

    protected override void OnRealtimeModelReplaced(BatterySyncModel previousModel, BatterySyncModel currentModel)
    {
        if (previousModel != null)
        {
            // Unregister from events
            previousModel.isShowingDidChange -= IsShowingDidChange;
        }

        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current Battery status.
            if (currentModel.isFreshModel)
                currentModel.isShowing = gameObject.activeSelf;

            // Update the battery status to match the new model
            UpdateBatteryVisibility();

            // Register for events so we'll know if the battery status changes later
            currentModel.isShowingDidChange += IsShowingDidChange;
        }
    }

    private void IsShowingDidChange(BatterySyncModel model, bool value)
    {
        // Update the mesh renderer
        UpdateBatteryVisibility();
    }

    private void UpdateBatteryVisibility()
    {
        gameObject.SetActive(model.isShowing);
    }

    public void SetBatteryActive(bool bol)
    {
        // Set the Battery Status on the model
        // This will fire the IsSHowingDidChange event on the model, which will update the renderer for both the local player and all remote players.
        model.isShowing = bol;
    }
}

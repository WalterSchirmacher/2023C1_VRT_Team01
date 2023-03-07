using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.UIElements;

public class ScrollViewSync : RealtimeComponent<ScrollViewModel>
{

    private Vector2 scrollvalue;
    public ScrollView scrollview;


      private void Awake()
    {
        scrollview = GetComponent<ScrollView>();
    }

    void UpdateScrollOffset()
    {
        scrollview.scrollOffset = model.scrollview;
     
    }

        void SubscribableScrollOffset(ScrollViewModel model, Vector2 change)
    {
        UpdateScrollOffset();
    }

    protected override void OnRealtimeModelReplaced(ScrollViewModel previousModel, ScrollViewModel currentModel)
    {
        if (previousModel != null)
        {
            previousModel.scrollviewDidChange -= SubscribableScrollOffset;
        }

        if (currentModel != null)
        {
            if (currentModel.isFreshModel)
            {
                currentModel.scrollview = scrollview.scrollOffset;
            }
            currentModel.scrollviewDidChange += SubscribableScrollOffset;
            UpdateScrollOffset();
        }
    }

    public void SendOutNewValue()
    {
        model.scrollview = scrollview.scrollOffset;

    }
}

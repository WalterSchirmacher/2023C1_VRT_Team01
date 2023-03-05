using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batteries : MonoBehaviour
{
    [HideInInspector]
    public bool isVisible;
    BatterySync sync;

    void Awake()
    {
        sync = GetComponent<BatterySync>();
        UpdateVisVar(true);
    }

    public void UpdateVisVar(bool vis)
    {
        isVisible = vis;
        ChangeVisibility();
        sync.SendOutNewVisibility();
    }

    public void ChangeVisibility()
    {
        gameObject.SetActive(isVisible);
    }
}

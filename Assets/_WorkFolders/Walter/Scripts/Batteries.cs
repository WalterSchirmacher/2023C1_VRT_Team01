using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batteries : MonoBehaviour
{
    public bool isVisible;
    BatterySync sync;

    void Awake()
    {
      sync = GetComponent<BatterySync>(); 
    }

    private void Start()
    {
        UpdateVisVar(true);
    }

    public void UpdateVisVar(bool vis)
    {
        isVisible = vis;
        ChangeVisibility();
       sync.SendOutVisibility();
    }

    public void ChangeVisibility()
    {
        gameObject.SetActive(isVisible);
    }
}

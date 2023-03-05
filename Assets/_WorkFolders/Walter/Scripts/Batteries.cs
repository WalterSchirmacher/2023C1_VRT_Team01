using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batteries : MonoBehaviour
{
    public bool isVisible = true;
    public GameObject homeBase;
    BatterySync sync;

    void Awake()
    {
      sync = GetComponent<BatterySync>();
        isVisible = true;
    }

    private void Start()
    {
        gameObject.SetActive(true);
        isVisible = true;
;    }

    public void UpdateVisVar(bool vis)
    {
        isVisible = vis;
        if(!isVisible)
        {
            GoHome();
        }
       sync.SendOutVisibility();
    }

    public void ChangeVisibility()
    {
        gameObject.SetActive(true);
        GoHome();
    }

    public void GoHome()
    {
        gameObject.SetActive(true);
        gameObject.transform.position = homeBase.transform.position;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batteries : MonoBehaviour
{
    public bool toBeDestroyed = false;
    public GameObject homeBase;
    BatterySync sync;

    void Awake()
    {
      sync = GetComponent<BatterySync>();
    }

    private void Start()
    {
        gameObject.SetActive(true);
;    }



    public void GoHome()
    {
        // gameObject.SetActive(true);
        //  gameObject.transform.position = homeBase.transform.position;
        BlowUpObj();
    }

    public void BlowUpObj()
    {
        if(toBeDestroyed)
        {
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public bool isHit = false;
    public bool fireActive = false;
    public GameObject fireParticleSys;
    EnemyShipSync sync;

    void Awake()
    {
        sync = GetComponent<EnemyShipSync>();
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if(collider.gameObject.CompareTag("CannonTarget") && !isHit)
        {
            isHit = true;
            sync.SendOutHitFireInfo();
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        isHit = false;
        sync.SendOutHitFireInfo();
    }

    public void SetFire(bool bol)
    {
        fireActive = bol;
        UpdateFire();
        sync.SendOutHitFireInfo();
    }
    public void UpdateFire()
    {
        fireParticleSys.SetActive(fireActive);
    }

}

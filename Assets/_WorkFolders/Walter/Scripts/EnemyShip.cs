using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public bool isHit = false;
    public GameObject fireParticleSys;

    private void Awake()
    {
        fireParticleSys.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("CannonTarget"))
        {
            isHit = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isHit = false;
    }
}

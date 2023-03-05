using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour
{

    public GameObject laserColliderParent, laserCollider, cannonPoint, targetObject;
    public EnemyShip theEnemy;
    public float showIonLaserTime = 1f;
    private Transform laserTransformer;
    public bool isFired = false;
    FireButtonSync sync;

    private void Awake()
    {
        sync = GetComponent<FireButtonSync>();
        laserColliderParent.SetActive(true);
        laserCollider.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        laserTransformer = laserColliderParent.transform;
    }

    public void FireIon(bool bol)
    {
        isFired = bol;
        UpdateIon();
        sync.SendOutFireBtnStatus();
    }

    public void UpdateIon()
    {
        if(isFired)
        {
            FireCannon();
        }
    }

    [ContextMenu("Fire Cannon")]
    public void FireCannon()
    {
        MeshRenderer mesh = laserCollider.GetComponent<MeshRenderer>();
        mesh.enabled = true;
        laserColliderParent.SetActive(true);
        laserCollider.SetActive(true);
        laserColliderParent.transform.LookAt(targetObject.transform);

        Vector3 vec = laserColliderParent.transform.position - targetObject.transform.position;
        float vecMag = vec.magnitude;
        laserCollider.transform.localPosition = new Vector3(laserCollider.transform.localPosition.x, laserCollider.transform.localPosition.y, vecMag/2);
        laserCollider.transform.localScale = new Vector3(vecMag, laserCollider.transform.localScale.y, laserCollider.transform.localScale.z);
        StartCoroutine(HideLaserCollider());

        if(theEnemy.isHit)
        {
            Debug.Log("Hit the Enemy");
            theEnemy.SetFire(true);
            theEnemy.UpdateFire();
        }
        else
        {
            Debug.Log("Missed!");

        }

    }
    IEnumerator HideLaserCollider()
    {
        yield return new WaitForSeconds(showIonLaserTime);
        laserCollider.SetActive(false);
        isFired = false;
        sync.SendOutFireBtnStatus();
    }
}

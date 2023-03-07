using System.Collections;
using UnityEngine;

public class FireButton : MonoBehaviour
{

    public GameObject laserColliderParent, laserCollider, cannonPoint, targetObject;
    public EnemyShip theEnemy;
    public float showIonLaserTime = 1f;
    private Transform laserTransformer;
    public bool isFired = false;
    public bool previousFire = false;
    FireButtonSync sync;
    public GameObject fireParticleSys;

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
        laserColliderParent.SetActive(true);
        laserCollider.SetActive(false);
    }

    public void FireIon()
    {
        isFired = true;
        //    previousFire = true;
        //   UpdateIon();
        sync.SendOutFireBtnStatus();
    }

    public void UpdateIon()
    {
        if (isFired)
        {
            FireCannon();
        }
    }

    public void CheckForHit()
    {
        if (theEnemy.isHit)
        {
            Debug.Log("Hit the Enemy");
            theEnemy.SetFire(true);
            theEnemy.UpdateFire();
        }
        else
        {
            Debug.Log("Missed!");
        }
        targetObject.GetComponent<MeshRenderer>().enabled = false;
    }

    [ContextMenu("Fire Cannon")]
    public void FireCannon()
    {
        isFired = true;
        sync.SendOutFireBtnStatus();
      //  MeshRenderer mesh = laserCollider.GetComponent<MeshRenderer>();
      //  mesh.enabled = true;
    //    Debug.Log("laser is at " + laserColliderParent.transform.rotation);

        laserColliderParent.transform.LookAt(targetObject.transform);
        laserCollider.SetActive(true);
  //      Debug.Log("laser is now at " + laserColliderParent.transform.rotation);
        //   Vector3 vec = laserColliderParent.transform.position - targetObject.transform.position;
        //    float vecMag = vec.magnitude;
        //   laserCollider.transform.localPosition = new Vector3(laserCollider.transform.localPosition.x, laserCollider.transform.localPosition.y, vecMag/2);
        //    laserCollider.transform.localScale = new Vector3(vecMag, laserCollider.transform.localScale.y, laserCollider.transform.localScale.z);
        StartCoroutine(HideLaserCollider());


    }
    IEnumerator HideLaserCollider()
    {
        yield return new WaitForSeconds(showIonLaserTime);
        theEnemy.SetFire(true);
        yield return new WaitForSeconds(0.5f);
        fireParticleSys.SetActive(true);
        laserCollider.SetActive(false);
        isFired = false;
        targetObject.GetComponent<MeshRenderer>().enabled = true;
        sync.SendOutFireBtnStatus();
    }
}

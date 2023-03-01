using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireButton : MonoBehaviour
{

    public GameObject laserColliderParent, laserCollider, cannonPoint, targetObject;
    public EnemyShip theEnemy;
    private Transform laserTransformer;

    // Start is called before the first frame update
    void Start()
    {
        laserTransformer = laserColliderParent.transform;
    }

    [ContextMenu("Fire Cannon")]
    void FireCannon()
    {
        MeshRenderer mesh = laserCollider.GetComponent<MeshRenderer>();
        mesh.enabled = true;

         laserColliderParent.transform.LookAt(targetObject.transform);

        Vector3 vec = laserColliderParent.transform.position - targetObject.transform.position;
        float vecMag = vec.magnitude;
       laserCollider.transform.localPosition = new Vector3(laserCollider.transform.localPosition.x, laserCollider.transform.localPosition.y, vecMag/2);
        laserCollider.transform.localScale = new Vector3(vecMag, laserCollider.transform.localScale.y, laserCollider.transform.localScale.z);
    }
}

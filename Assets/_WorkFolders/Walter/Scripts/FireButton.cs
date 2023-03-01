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

            Vector3 centerPos = new Vector3(cannonPoint.transform.position.x + targetObject.transform.position.x, cannonPoint.transform.position.z + targetObject.transform.position.z) / 2f;

           float scaleX = Mathf.Abs(cannonPoint.transform.position.x - targetObject.transform.position.x);
           float scaleZ = Mathf.Abs(cannonPoint.transform.position.z - targetObject.transform.position.z);

        laserColliderParent.transform.position = centerPos;
           laserColliderParent.transform.localScale = new Vector3(scaleX, 0, scaleZ);

      /*   Vector3 objectScale = laserColliderParent.transform.localScale;
        float distance = Vector3.Distance(targetObject.transform.position, cannonPoint.transform.position);
        Vector3 newScale = new Vector3(objectScale.x, objectScale.y, distance);
        laserColliderParent.transform.localScale = newScale;
      */
    }
}

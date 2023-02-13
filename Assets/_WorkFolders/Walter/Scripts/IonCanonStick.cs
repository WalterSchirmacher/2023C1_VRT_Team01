using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonCanonStick : MonoBehaviour
{

    private Vector3 initialAngles;
    // Start is called before the first frame update
    void Start()
    {
        initialAngles = this.transform.rotation.eulerAngles;
        Debug.Log("inital angles are " + initialAngles.x + ", " + initialAngles.y + " " + initialAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentAngles = this.transform.rotation.eulerAngles;
        Debug.Log("current angles are " + currentAngles.x + ", " + currentAngles.y + " " + currentAngles.z);
    }
}

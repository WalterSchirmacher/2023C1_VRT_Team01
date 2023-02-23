using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonCanonFire : MonoBehaviour
{
    public GameObject ionLaserStart;
    public GameObject targetingCircle;
    public GameObject targetToHit;
    private LineRenderer Line;

    // Start is called before the first frame update
    void Start()
    {
        Line = GetComponent<LineRenderer>();
        Line.SetPosition(0, ionLaserStart.transform.position);
        Line.SetPosition(1, targetingCircle.transform.position);
        Line.startWidth = 0.05f;
        Line.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonCanonFire : MonoBehaviour
{
    public GameObject ionLaserLeft, ionLaserRight, ionLaserBottom;
    public GameObject targetingCircle;
    public GameObject targetToHit;
    public GameObject CannonVisible, CannonTransparent;
    public IonTargeting leftRightCTRL, forwardBackCTRL;
    public GameObject leftRightCTRLOff, forwardBackCTRLOff;
    [HideInInspector]
    public bool isPoweredUp = false;
    private LineRenderer lineLeft, lineRight, lineCenter;
    private float startWidth = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        lineLeft = ionLaserLeft.GetComponent<LineRenderer>();
        lineRight = ionLaserRight.GetComponent<LineRenderer>();
        lineCenter = ionLaserBottom.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawLines();
    }

    public void DrawLines()
    {
        lineLeft.SetPosition(0, ionLaserLeft.transform.position);
        lineLeft.SetPosition(1, targetingCircle.transform.position);
        lineLeft.startWidth = startWidth;
        lineLeft.useWorldSpace = true;

        lineRight.SetPosition(0, ionLaserRight.transform.position);
        lineRight.SetPosition(1, targetingCircle.transform.position);
        lineRight.startWidth = startWidth;
        lineRight.useWorldSpace = true;

        lineCenter.SetPosition(0, ionLaserBottom.transform.position);
        lineCenter.SetPosition(1, targetingCircle.transform.position);
        lineCenter.startWidth = startWidth;
        lineCenter.useWorldSpace = true;
    }

    public void MakeVisible()
    {
       if(!leftRightCTRL.moveObj && !forwardBackCTRL.moveObj)
        {
            CannonVisible.SetActive(true);
            CannonTransparent.SetActive(false);
        }
    }

    public void MakeTransparent()
    {
        CannonVisible.SetActive(false);
        CannonTransparent.SetActive(true);
    }

    [ContextMenu("TestCannon")]
    public void TestCannonnn()
    {
        StartUpCannon();
    }

  
    public void StartUpCannon()
    {
        isPoweredUp = true;
        leftRightCTRLOff.SetActive(false);
        forwardBackCTRLOff.SetActive(false);
        leftRightCTRL.gameObject.SetActive(true);
        forwardBackCTRL.gameObject.SetActive(true);
    }
}

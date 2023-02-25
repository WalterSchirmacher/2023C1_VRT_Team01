using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTarget : MonoBehaviour
{
    public enum Location { Back, Front, Left, Right };
    public Location location;
    public IonTargeting ionLeftRight, ionForwardBack;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        switch (location)
        {
            case Location.Back:
                ionForwardBack.backHit = true;
                break;
            case Location.Front:
                ionForwardBack.forwardHit = true;
                break;
            case Location.Left:
                ionLeftRight.leftHit = true;
                break;
            case Location.Right:
                ionLeftRight.rightHit = true;
                break;
            default:
                Debug.Log("Collider Not Found");
                break;
        }
        Debug.Log("collion " + location.ToString());
    }
    private void OnCollisionExit(Collision collision)
    {
        switch (location)
        {
            case Location.Back:
                ionForwardBack.backHit = false;
                break;
            case Location.Front:
                ionForwardBack.forwardHit = false;
                break;
            case Location.Left:
                ionLeftRight.leftHit = false;
                break;
            case Location.Right:
                ionLeftRight.rightHit = false;
                break;
            default:
                Debug.Log("Collider Not Found");
                break;
        }
        Debug.Log("collion stopped" + location.ToString());
    }
}

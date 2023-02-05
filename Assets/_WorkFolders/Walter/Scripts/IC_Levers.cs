using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IC_Levers : MonoBehaviour
{
    public GameObject leverName;
    public GameObject nextObj;

    private Quaternion objRotation;
    private bool isClickable = true;
    private float alpha = 0.5f;

    public void ActivateNextObj()
    {
        objRotation = leverName.transform.localRotation;
        if(isClickable && objRotation.eulerAngles.z > 50)
        {
            isClickable = false;
            ChangeAlpha(leverName.GetComponent<Renderer>().material, alpha);
            nextObj.SetActive(true);
        }
    }
    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}
                                
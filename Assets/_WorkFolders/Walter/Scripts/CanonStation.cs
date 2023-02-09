using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonStation : MonoBehaviour
{

    private GameObject gObject;
   // private MeshRenderer meshComponent;
    private float alpha = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        gObject = this.gameObject;
     //   meshComponent = gObject.GetComponent<MeshRenderer>();
     //   meshComponent.enabled = false;
        ChangeAlpha(gObject.GetComponent<Renderer>().material, alpha);
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
}

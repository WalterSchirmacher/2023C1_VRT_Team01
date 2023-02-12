using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IonCanonBase : MonoBehaviour
{

    public TextMeshPro TextMeshObj;
    public string defaultText;
    public string activateText;

    // Start is called before the first frame update
    void Start()
    {
        ChangeText(defaultText);
    }

    public void PowerOn()
    {
        ChangeText(activateText);
    }

    private void ChangeText(string theText)
    {
         Debug.Log("Changing canon text");
        TextMeshObj.SetText(theText);
    }
}

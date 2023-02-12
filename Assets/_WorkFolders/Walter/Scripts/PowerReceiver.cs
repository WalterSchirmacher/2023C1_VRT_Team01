using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerReceiver : MonoBehaviour
{
    public TextMeshPro txtInfo;
    public static int ionPower = 0;
    public string[] ionPowerPercent = new string[] {"0%", "33%", "66%", "100%"};
    public string defaultText = "Power Level: ";

    public void Awake()
    {
      //  txtInfo = this.transform.GetComponentInParent<TextMeshPro>();
        ChangePowerText(defaultText + ionPowerPercent[ionPower]);
    }

    private void OnTriggerEnter(Collider other)
    {
         Debug.Log(other.gameObject.name);
        // Hide PowerPellet
        other.gameObject.SetActive(false);
        Debug.Log(ionPower);
        if(ionPower < 3)
        {
            // Increase ionPower variable by 1
            Debug.Log("Increasing Power");
            ionPower++;
            ChangePowerText(defaultText + ionPowerPercent[ionPower]);
        }

    }

    private void ChangePowerText(string theText)
    {
        Debug.Log("Chaning text");
        txtInfo.SetText(theText);
    }
}

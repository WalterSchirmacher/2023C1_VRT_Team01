using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerReceiver : MonoBehaviour
{

    public TextMeshPro TextMeshObj;
    public static int ionPower = 0;
    public string[] ionPowerPercent = new string[] {"0%", "33%", "66%", "100%"};
    public string defaultText = "Power Level: ";
    public AudioSource powerIncreaseSound;
    public AudioSource finalPowerSound;
    private bool musicOn = false;

    public void Start()
    {
        //  txtInfo = this.transform.GetComponentInParent<TextMeshPro>();
        ChangeText(defaultText + ionPowerPercent[ionPower]);
    }

    private void OnTriggerEnter(Collider other)
    {
     //    Debug.Log(other.gameObject.name);
        // Hide PowerPellet
        other.gameObject.SetActive(false);
     //   Debug.Log(ionPower);
        if(ionPower < 3)
        {
            // Increase ionPower variable by 1
        //    Debug.Log("Increasing Power");
            ionPower++;
            ChangeText(defaultText + ionPowerPercent[ionPower]);
            ChangeSoundFx();
        }

    }

    private void ChangeText(string theText)
    {
      //  Debug.Log("Changing text");
        TextMeshObj.SetText(theText);
    }

    private void ChangeSoundFx()
    {
        if (ionPower > 0 && !musicOn)
        {
            musicOn = true;
            powerIncreaseSound.Play();
        }

        float pitchLevel = 1 * ionPower;
        if (pitchLevel > 3)
        {
            pitchLevel = 3;
        }
        Debug.Log("pitch is now: " + pitchLevel);
        powerIncreaseSound.pitch = pitchLevel;
    }

}

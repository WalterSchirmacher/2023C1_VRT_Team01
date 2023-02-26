using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerReceiver : MonoBehaviour
{

    public TextMeshPro TextMeshObj;
    public Light lightSource;
    public IonCanonFire cannon;
    public static int ionPower = 0;
    public string[] ionPowerPercent = new string[] {"0%", "33%", "66%", "100%"};
    public string defaultText = "Power Level: ";
    public AudioSource powerIncreaseSound;
    public string batteryTag = "Battery";
    private bool musicOn = false;

    public void Start()
    {
        //  txtInfo = this.transform.GetComponentInParent<TextMeshPro>();
        ChangeText(defaultText + ionPowerPercent[ionPower]);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I see a " + other.name + " " + other.tag);
        if(other.gameObject.CompareTag(batteryTag))
        {
            other.gameObject.SetActive(false);
            if (ionPower < 3)
            {
                // Increase ionPower variable by 1
                ionPower++;
                ChangeText(defaultText + ionPowerPercent[ionPower]);
                ChangeSoundFx();

                float perNum = float.Parse(ionPowerPercent[ionPower].Replace("%", ""));
                int perINum = (int)perNum;
                if(perINum > 0 && perINum <= 100)
                {
                    lightSource.intensity = perNum;
                } else
                {
                    Debug.Log("Error in number entry. Value is: " + ionPowerPercent[ionPower]);
                    Debug.Log("This value convereted to: " + perINum);
                }
            }

            if (ionPower == 3)
            {
                cannon.StartUpCannon();
            }
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

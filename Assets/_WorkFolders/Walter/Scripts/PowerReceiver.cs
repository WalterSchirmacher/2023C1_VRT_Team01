using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerReceiver : MonoBehaviour
{

    public TextMeshPro TextMeshObj;
    public Light lightSource;
    public IonCanonFire cannon;
    public GameObject pushButton;
    public int ionPower = 0;
    public string[] ionPowerPercent = new string[] {"0%", "33%", "66%", "100%"};
    public string defaultText = "Power Level: ";
    public AudioSource powerIncreaseSound;
    public string batteryTag = "Battery";
    private bool musicOn = false;
    PowerReceiverSync sync;

    public void Start()
    {
       if(pushButton)
        {
            pushButton.SetActive(false);
        }
       else
        {
            Debug.Log("Push Button Not Defined!");
        }
        UpdateText();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I see a " + other.name + " " + other.tag);
        if(other.gameObject.GetComponent<Batteries>())
        {
            HideBattery(other.gameObject);
            IncreaseIonPowerNum();
        }
    }

    public void IncreaseIonPowerNum()
    {
        if (ionPower < 3)
        {
            // Increase ionPower variable by 1
            ionPower++;
            sync.SendOutNewCount();
        }

        UpdatePowerReceiver();

    }

    public void HideBattery(GameObject gameObj)
    {
        Batteries battery = gameObj.GetComponent<Batteries>();
        battery.GoHome();
    }
    public void UpdatePowerReceiver()
    {

        if (ionPower == 3 && !cannon.isPoweredUp)
        {
            cannon.StartUpCannon();
        }
        UpdateText();
        UpdateSoundFx();
        UpdateLightLevel();
    }


    private void UpdateLightLevel()
    {
        float perNum = float.Parse(ionPowerPercent[ionPower].Replace("%", ""));
        int perINum = (int)perNum;
        if (perINum > 0 && perINum <= 100)
        {
            lightSource.intensity = perNum;
        }
        else
        {
            Debug.Log("Error in number entry. Value is: " + ionPowerPercent[ionPower]);
            Debug.Log("This value convereted to: " + perINum);
        }
    }

    private void UpdateText()
    {
      //  Debug.Log("Changing text");
        TextMeshObj.SetText(defaultText + ionPowerPercent[ionPower]);
    }

    private void UpdateSoundFx()
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

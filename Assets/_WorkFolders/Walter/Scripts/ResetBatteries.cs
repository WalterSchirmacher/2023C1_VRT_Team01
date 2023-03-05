using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBatteries : MonoBehaviour
{

    public Batteries battery1, battery2, battery3, battery4, battery5, battery6;
    // Start is called before the first frame update
   public void ResetBatteriesMakeViewable()
    {
        battery1.UpdateVisVar(true);
        battery2.UpdateVisVar(true);
        battery3.UpdateVisVar(true);
        battery4.UpdateVisVar(true);
        battery5.UpdateVisVar(true);
        battery6.UpdateVisVar(true);
    }
}

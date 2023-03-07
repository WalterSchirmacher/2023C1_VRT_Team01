using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonParticles : MonoBehaviour
{

    public FireButton fireButton;


    // Update is called once per frame
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("CannonTarget"))
        {
            fireButton.CheckForHit();
        }
        else
        {
            Debug.Log("Particles Did not hit CannonTarget");
        }
    }
}

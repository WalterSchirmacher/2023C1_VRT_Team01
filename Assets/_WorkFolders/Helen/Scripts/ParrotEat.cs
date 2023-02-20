using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ParrotEat : MonoBehaviour
{
    public Animator anim;
    //public string animationTriggerName = "ParrotEating";
    //public Animation anim;

    private XRSocketInteractor socketInteractor;
    private GameObject objectToDestroy;
    private bool isObjectInSocket;
    public AudioClip parrotNoise; 

    private void Start()
    {
       
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.onSelectEntered.AddListener(ObjectEnteredSocket);
    }

    private void ObjectEnteredSocket(XRBaseInteractable interactable)
    {
        
        objectToDestroy = interactable.gameObject;
        isObjectInSocket = true;
        Invoke("DestroyObject", 1f);
        
    }

    private void DestroyObject()
    {
        
        if (isObjectInSocket)
        {
            Destroy(objectToDestroy);
            AudioSource.PlayClipAtPoint(parrotNoise, objectToDestroy.transform.position); 
            anim.SetTrigger("dance");
            isObjectInSocket = false;
           
        }
    }
}


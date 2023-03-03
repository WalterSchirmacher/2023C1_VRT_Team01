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
    public bool isObjectInSocket;
    public AudioClip parrotNoise;
    ParrotEatSync sync;


    private void Awake()
    {
        sync = GetComponent<ParrotEatSync>();
    }
    private void Start()
    {
       
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.onSelectEntered.AddListener(ObjectEnteredSocket);
    }

    public void ObjectEnteredSocket(XRBaseInteractable interactable)
    {
        
        objectToDestroy = interactable.gameObject;
        isObjectInSocket = true;
        Invoke("DestroyObject", 1f);
        
    }

    public void DestroyObject()
    {
        
        if (isObjectInSocket)
        {
            Destroy(objectToDestroy);
            AudioSource.PlayClipAtPoint(parrotNoise, objectToDestroy.transform.position); 
            anim.SetTrigger("dance");
            isObjectInSocket = false;
            sync.SendOutNewInfo();
        }
    }
}


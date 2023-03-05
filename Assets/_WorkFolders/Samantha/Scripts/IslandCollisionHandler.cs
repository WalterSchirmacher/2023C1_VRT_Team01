using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandCollisionHandler : MonoBehaviour
{

    public bool collided;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
        Debug.Log("YOU RAN AGROUND!!");
    }

    private void OnCollisionEnter(Collision collision)
    {
        collided = true;
        Debug.Log("YOU RAN AGROUND!!");
        Debug.Log(collision.gameObject.name);
    }
}

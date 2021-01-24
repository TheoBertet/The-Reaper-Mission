using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class OneShotAnimation : MonoBehaviour
{
    public Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AlertObservers(string Message)
    {
        if(Message.Equals("Finished"))
        {
            Destroy(gameObject);
        }
    }
}

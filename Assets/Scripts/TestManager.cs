using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        StartCoroutine(MessageLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //So that we are not blocking the main thread(and as a result freeze the entire app) if there is no response
    IEnumerator MessageLoop(){
        NetworkManager.GetResponse(Vector3.down);
        yield return new WaitForEndOfFrame();
    }
}

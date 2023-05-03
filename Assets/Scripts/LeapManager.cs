using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class LeapManager : MonoBehaviour
{
    LeapServiceProvider leapServiceProvider;
    void Awake(){
        leapServiceProvider = GetComponent<LeapServiceProvider>();
        leapServiceProvider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Frame frame = leapServiceProvider.CurrentFrame;
        if (frame.Hands.Count <= 0) return;
        Hand hand = frame.Hands[0];
        Vector3 handPosition = hand.PalmPosition;
        LogPosition(handPosition);
        SendPosition(handPosition);
    }

    void LogPosition(Vector3 position) {
        Debug.Log(position);
    }

    void SendPosition(Vector3 position) {
        NetworkManager.GetResponse(position);
    }

    
}

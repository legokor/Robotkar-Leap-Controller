# Robotkar-Leap-Controller

## Preconditions
 - Unity version: [2021.3.21f1](https://unity.com/releases/editor/whats-new/2021.3.21)
 - Leap SDK: [Gemini 5.7.2](https://developer.leapmotion.com/tracking-software-download)
 - Tutorial
     - [Unity leap plugin](https://docs.ultraleap.com/unity-api/The-Basics/getting-started.html)
     - [Hand tracking data](https://docs.ultraleap.com/unity-api/Using%20Hand%20Tracking%20Data/getting-tracking-data.html)

## Robotic Arm Simulator
 - [Unity project](https://github.com/legokor/RoboticArmNetworkSimulator)

## Unity - Arm communication
 - Cartesian to Cylindrical coordinates
     - (x, y, z) &rarr; (r, fi, z)
         - r = $\sqrt{x^2 + y^2}$
         - fi = $\tan^{-1}$($\frac{y}{x}$)
         - z = z
 - Endpoint: `GET /action/coord/cyl?r=0&f=0&z=0 HTTP/1.1`

## Retreiving hand data
```
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
}
```

## Sending data
```
var request = WebRequest.Create(requestUrl);
request.Method = "GET";
using var webResponse = request.GetResponse();
using var webStream = webResponse.GetResponseStream();

using var reader = new StreamReader(webStream);
var data = reader.ReadToEnd();
```

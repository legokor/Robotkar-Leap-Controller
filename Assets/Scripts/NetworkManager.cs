using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using UnityEditor.PackageManager;
using UnityEngine;

public class NetworkManager
{

    class CylindricalCoordinate {
        public CylindricalCoordinate(Vector3 position/*, Vector3 origin*/) {
            this.r = Math.Sqrt(Math.Pow(position.x, 2) + Math.Pow(position.z, 2)); //Vector3.Distance is ezt csinálja
            this.f = Math.Atan2(position.x, position.z); //outputs 360 degree angle
            this.z = position.y; //y is up in Unity
        }
        public double r { get; private set; }
        public double f { get; private set; }
        public double z { get; private set; }
    }
    HttpClient client = new HttpClient();
    public NetworkManager()
    {

    }
    
    public static void GetResponse(Vector3 position)
    {
        var baseUrl = "http://localhost:8000";
        var coordinates = new CylindricalCoordinate(position);
        var parameterUrl = $"/action/coord/cyl?r={coordinates.r}&f={coordinates.f}&z={coordinates.z}";
        var requestUrl = baseUrl + parameterUrl;
        //Debug.Log(requestUrl);
        var request = WebRequest.Create(requestUrl);
        request.Method = "GET";

        using var webResponse = request.GetResponse();
        using var webStream = webResponse.GetResponseStream();

        using var reader = new StreamReader(webStream);
        var data = reader.ReadToEnd();
    }
    
}

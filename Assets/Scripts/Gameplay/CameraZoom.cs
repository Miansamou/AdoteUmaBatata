using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private int MinZoom = 1;
    private int MaxZoom = 8;

    // Update is called once per frame
    void Update()
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize 
            + TouchSystem.instance.Zoom(), MinZoom, MaxZoom);
    }
}

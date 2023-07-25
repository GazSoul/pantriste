 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraExtend : MonoBehaviour
{   
    public Camera cam;
    public float zoom;
    private void OnTriggerEnter2D(Collider2D other) {
        cam.orthographicSize = 15;
        //cam.orthographicSize += zoom;

    }
}

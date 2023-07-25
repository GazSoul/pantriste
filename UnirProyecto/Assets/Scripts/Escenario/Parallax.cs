using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos, startposy, lengthy;
    public GameObject cam;
    public float parallexEffect;
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startposy = transform.position.y;
        lengthy = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallexEffect));
        float dist = (cam.transform.position.x * parallexEffect);
        float tempy = (cam.transform.position.y * (1 - parallexEffect));
        float disty = (cam.transform.position.y * parallexEffect);
        transform.position = new Vector3(startpos + dist, startposy + disty, transform.position.z);
        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
        if (tempy > startposy + lengthy) startposy += lengthy;
        else if (tempy < startposy - lengthy) startposy -= lengthy;
    }
}
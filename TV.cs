using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    public GameObject plane;
    public WebCamTexture webcam = null;
    //public Microphone micro = null;
    // Start is called before the first frame update
    void Start()
    {
        webcam = new WebCamTexture();
        webcam.Play();
        plane.GetComponent<Renderer>().material.mainTexture = webcam;
        if (!webcam.isPlaying) webcam.Play();

        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
            Debug.Log(devices[i].name);

        if(Microphone.devices.Length > 0)
        {
            AudioSource audioClip = GetComponent<AudioSource>();
            audioClip.clip = Microphone.Start("", true, 10, 44100);
            audioClip.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour {
    private CinemachineVirtualCamera vCamera;
    private float shakeIntensity = 0f;
    private float shakeTimer=0.2f;


    private float timer;
   private CinemachineBasicMultiChannelPerlin _channelPerlin;

     void Start() {

        timer = 0f;
        
        vCamera= GameObject.Find("VCam").GetComponent<CinemachineVirtualCamera>();

        StopShaking();
     

     // _channelPerlin = vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
     

    }

    public void CameraShake() {

        CinemachineBasicMultiChannelPerlin _channelPerlin = vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _channelPerlin.m_AmplitudeGain = shakeIntensity;

        timer= shakeTimer;
    
    }

    public void StopShaking() {

        CinemachineBasicMultiChannelPerlin _channelPerlin = vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _channelPerlin.m_AmplitudeGain = 0f;

        timer = 0f;
    
    }

    

    // Update is called once per frame
    void Update()
    {

        if (timer>0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0) {

                StopShaking();
            
            }


        }


    }


    public void StartShaking(float shakeInts, float timeShake) {

        shakeIntensity = shakeInts;
        shakeTimer = timeShake;

        CameraShake();
    }

}

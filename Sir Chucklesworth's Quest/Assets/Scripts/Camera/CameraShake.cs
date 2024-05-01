using UnityEngine;
using Cinemachine;
using System.Collections.Generic;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    private void Awake()
    {
        if (virtualCamera == null)
        {
            Debug.LogError("CinemachineVirtualCamera is not assigned.");
            return; 
        }

        virtualCameraNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if (virtualCameraNoise == null)
        {
            Debug.LogError("CinemachineBasicMultiChannelPerlin component not found on virtual camera.");
            return; 
        }

        ResetIntensity();
    }


    public void ShakeCamera(float intensity, float shakeTime)
    {
        if (virtualCameraNoise == null)
        {
            Debug.LogError("Attempting to shake camera, but virtualCameraNoise is not set.");
            return; 
        }

        virtualCameraNoise.m_AmplitudeGain = intensity;
        StartCoroutine(WaitTime(shakeTime));
    }



    IEnumerator WaitTime(float shakeTime)
    {
        yield return new WaitForSeconds(shakeTime);
        ResetIntensity();
    }

    void ResetIntensity()
    {
        virtualCameraNoise.m_AmplitudeGain = 0f;
    }
}

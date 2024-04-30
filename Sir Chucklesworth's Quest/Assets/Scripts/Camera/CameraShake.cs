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
            return; // Stop further execution if virtualCamera is null
        }

        virtualCameraNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        if (virtualCameraNoise == null)
        {
            Debug.LogError("CinemachineBasicMultiChannelPerlin component not found on virtual camera.");
            return; // Stop further execution if virtualCameraNoise is null
        }

        ResetIntensity();
    }


    public void ShakeCamera(float intensity, float shakeTime)
    {
        if (virtualCameraNoise == null)
        {
            Debug.LogError("Attempting to shake camera, but virtualCameraNoise is not set.");
            return; // Prevent further execution and avoid the NullReferenceException
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

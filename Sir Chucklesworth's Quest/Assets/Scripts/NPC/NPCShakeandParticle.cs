using System.Collections;
using UnityEngine;

public class NPCShakeandParticle: MonoBehaviour
{

    [Header("Effects")]
    public GameObject damageEffectPrefab;  // Assign your particle effect prefab in the Unity Inspector

    [Header("Camera Shake Parameters")]
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private float shakeIntensity = 5;
    [SerializeField] private float shakeTime = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))  // Ensure the collider tag is set to "NPC" on the NPC GameObject
        {
            TriggerDamageEffects();
        }
        void TriggerDamageEffects()
        {
            if (damageEffectPrefab)
            {
                // Instantiate the particle effect at the position of the NPC
                Instantiate(damageEffectPrefab, transform.position, Quaternion.identity);
                Debug.Log("Particle system instantiated at " + transform.position);

            }

            if (cameraShake)
            {
                cameraShake.ShakeCamera(shakeIntensity, shakeTime);
            }

            }
        }
    }


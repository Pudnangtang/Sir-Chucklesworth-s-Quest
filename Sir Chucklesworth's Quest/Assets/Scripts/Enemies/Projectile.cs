using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage = 20;
    private Transform player;
    private Vector2 target;
    public AudioClip hitSound;
    private AudioSource audioSource;

    [Header("Camera Shake Parameters")]
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private float shakeIntensity = 5;
    [SerializeField] private float shakeTime = 1;

    [Header("Particle Effect")]
    public GameObject hitEffectPrefab;  // Assign your particle effect prefab in the Unity Inspector

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("NPC").transform;
        target = new Vector2(player.position.x, player.position.y);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if ((Vector2)transform.position == target)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
        else if (other.CompareTag("NPC"))
        {
            var npcHealth = other.GetComponent<NPCHealth>();
            if (npcHealth != null)
            {
                npcHealth.TakeDamage(damage);
                audioSource.PlayOneShot(hitSound);
                cameraShake.ShakeCamera(shakeIntensity, shakeTime);
                InstantiateHitEffect();
                
            }
            DestroyProjectile();
        }
    }

    private void InstantiateHitEffect()
    {
        if (hitEffectPrefab == null)
        {
            Debug.LogError("Hit effect prefab is not assigned.");
            return;
        }

        Debug.Log("Instantiating hit effect.");
        GameObject effect = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
    }



    void DestroyProjectile()
    {
        if (audioSource.isPlaying)
        {
            Destroy(gameObject, audioSource.clip.length);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    private AudioSource attackSound;

    public GameObject attackEffect;  // Assign your particle effect in the Unity Inspector

    private bool canAttack = true;

    [Header("Camera Shake Parameters")]
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private float shakeIntensity = 5;
    [SerializeField] private float shakeTime = 1;

    void Start()
    {
        attackSound = GetComponent<AudioSource>();  // Get the AudioSource component
    }

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            // then you can attack
            if (Input.GetKeyDown(KeyCode.Space) && canAttack)
            {
                cameraShake.ShakeCamera(shakeIntensity, shakeTime);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                    Debug.Log("Enemy Taken damage");
                    Attack();
                }
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void Attack()
    {
        //the particle effect
        GameObject effectInstance = Instantiate(attackEffect, transform.position, Quaternion.identity);
        ParticleSystem effectParticleSystem = effectInstance.GetComponent<ParticleSystem>();

        if (effectParticleSystem != null)
        {
            var mainModule = effectParticleSystem.main;
            mainModule.loop = false;

            effectParticleSystem.Play();
        }

        canAttack = false; 
        cameraShake.ShakeCamera(shakeIntensity, shakeTime);
        StartCoroutine(ResetAttack());
        attackSound.Play();  // Play the attack sound
    }


    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1); 
        canAttack = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}

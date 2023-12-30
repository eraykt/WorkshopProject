using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 50f;

    public Transform rightGun, leftGun;

    public BlasterControlller blasterPrefab;

    public GameManager gameManager;

    private AudioSource audioSource;
    
    public Animator anim;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");

        transform.Translate(moveSpeed * Time.deltaTime * x, 0, 0);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -25f, 25f), transform.position.y,
            transform.position.z);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(blasterPrefab, rightGun.position, blasterPrefab.transform.rotation);
            Instantiate(blasterPrefab, leftGun.position, blasterPrefab.transform.rotation);
            audioSource.Play();
            anim.SetTrigger("Fire");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().Explosion(false);
            gameManager.LowerHealth();
        }
    }
}
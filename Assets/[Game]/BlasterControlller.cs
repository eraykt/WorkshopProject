using UnityEngine;

public class BlasterControlller : MonoBehaviour
{
    public float moveSpeed = 35f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        rb.velocity = Vector3.forward * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController hitObject = other.GetComponent<EnemyController>();
            hitObject.Explosion(true);
            Destroy(gameObject);
        }
    }
}
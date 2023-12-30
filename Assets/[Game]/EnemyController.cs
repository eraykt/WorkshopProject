using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 50f;
    private Rigidbody rb;

    private GameManager gameManager;
    
    public GameObject explosionParticle;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        rb.velocity = transform.forward * moveSpeed;
    }

    public void Explosion(bool isScore)
    {
        if (isScore)
            gameManager.AddScore();
            
        Destroy(gameObject);
        //Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collider"))
        {
            gameManager.LowerHealth();
            Destroy(gameObject);
        }        
    }
    
    
}
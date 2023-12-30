using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float timer;
    public float spawnRate = 1f;
    public EnemyController enemyPrefab;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            timer = 0f;

            float randomPosX = Random.Range(-20f, 20f);
            Vector3 spawnPos = new Vector3(randomPosX, transform.position.y, transform.position.z);
            Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
        }
    }
}
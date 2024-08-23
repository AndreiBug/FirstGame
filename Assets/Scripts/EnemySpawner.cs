using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private float SpawnInterval = 5f;

    private void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            // Spawn enemy on the left side
            InstantiateEnemy(new Vector3(Random.Range(-4f, -3f), Random.Range(-1f, 1f), 0));

            yield return new WaitForSeconds(SpawnInterval);

            // Spawn enemy on the right side
            InstantiateEnemy(new Vector3(Random.Range(3f, 4f), Random.Range(-1f, 1f), 0));

            yield return new WaitForSeconds(SpawnInterval);
        }
    }

    private void InstantiateEnemy(Vector3 position)
    {
        GameObject newEnemy = Instantiate(Enemy, position, Quaternion.identity);
        // Optionally, you can set up the new enemy here (e.g., set health, behaviors, etc.)
    }
}

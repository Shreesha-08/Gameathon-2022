using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject shooterPrefab;
    // [SerializeField]
    // private GameObject creeperPrefab;

    [SerializeField]
    private float shooterInterval = 3.5f;
    [SerializeField]
    private float startShooterSpawn = 3.5f;
    // [SerializeField]
    // private float creeperInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        new WaitForSeconds(startShooterSpawn);
        StartCoroutine(spawnEnemy(shooterInterval, shooterPrefab));
        // StartCoroutine(spawnEnemy(creeperInterval, creeperPrefab));
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-3f, 3), Random.Range(-3f, 3f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}

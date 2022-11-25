using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject shooterPrefab;
    [SerializeField]
    private GameObject creeperPrefab;

    [SerializeField]
    private float shooterInterval = 3.5f;
    [SerializeField]
    private float creeperInterval = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(shooterInterval, shooterPrefab));
        StartCoroutine(spawnEnemy(creeperInterval, creeperPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}

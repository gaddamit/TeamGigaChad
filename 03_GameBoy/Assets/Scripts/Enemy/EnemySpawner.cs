using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyParent;
    [SerializeField] private float spawnStartDelay = 3;
    [SerializeField] private float spawnRate = 5;

    private Bounds bounds;
    // Start is called before the first frame update
    void Start()
    {
        bounds = this.GetComponent<SpriteRenderer>().bounds;
        if(enemyPrefab != null)
        {
            StartCoroutine(SpawnEnemy());
        }        
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnStartDelay);
        while(true)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, enemyParent.transform);
            yield return new WaitForSeconds(spawnRate);
        }
    }        
}


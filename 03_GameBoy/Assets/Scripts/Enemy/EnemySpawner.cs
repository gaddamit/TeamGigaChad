using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnStartDelay = 3;
    [SerializeField] private float _spawnRate = 5;
    [SerializeField] private GameObject _spawnArea;

    private Bounds _bounds;

    // Start is called before the first frame update
    void Start()
    {
        _bounds = _spawnArea.GetComponent<SpriteRenderer>().bounds;
        if(_enemyPrefab != null)
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
        yield return new WaitForSeconds(_spawnStartDelay);
        while(true)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(_bounds.min.x, _bounds.max.x), Random.Range(_bounds.min.y, _bounds.max.y));
            Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity, transform);
            yield return new WaitForSeconds(_spawnRate);
        }
    }        
}


using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnStartDelay = 3;
    [SerializeField] private float _spawnRate = 1;
    [SerializeField] private GameObject _spawnArea;
    [SerializeField] private int _totalSpawn = 10;
    private Bounds _bounds;
    private int _remainingEnemies = 0;

    public UnityEvent OnAllEnemiesDead;
    // Start is called before the first frame update
    void Start()
    {
        _remainingEnemies = _totalSpawn;
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
        while(_totalSpawn-- > 0)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(_bounds.min.x, _bounds.max.x), Random.Range(_bounds.min.y, _bounds.max.y));
            GameObject enemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity, transform);
            enemy.GetComponent<Enemy>().OnEnemyDeath += () => OnSpawnDeath();
            yield return new WaitForSeconds(_spawnRate + Random.Range(1, 2));
        }
    }     

    private void OnSpawnDeath()
    {
        _remainingEnemies--;
        if(_remainingEnemies <= 0)
        {
            OnAllEnemiesDead?.Invoke();
        }
    }   
}

